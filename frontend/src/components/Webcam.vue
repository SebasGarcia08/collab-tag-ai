<template>
  <div class="float-right md:float-right">
    <div class="flex justify-center">
      <video
        autoplay
        playsinline
        muted
        ref="wc"
        width="500"
        height="500"
      ></video>
    </div>
    <div class="flex justify-center">

<button class="w-1/4 py-2 px-4 bg-blue-500 hover:bg-blue-600 rounded-md text-white flex justify-center" 
    v-on:click="handleButton(0)"> {{classNames[0]}} {{ numSamples[0] }} </button>

    <button class="w-1/4 py-2 px-4 bg-blue-500 hover:bg-blue-600 rounded-md text-white flex justify-center" 
    type="button" v-on:click="handleButton(1)"> {{classNames[1]}} {{ numSamples[1] }}</button>
    
    <button class="w-1/4 py-2 px-4 bg-blue-500 hover:bg-blue-600 rounded-md text-white flex justify-center" 
    type="button" v-on:click="handleButton(2)"> {{classNames[2]}} {{ numSamples[2] }} </button>
    
    </div>

    <button type="button" id="train" v-on:click="doTraining">
      Train Network
    </button>
    <div id="dummy">
      Once training is complete, click 'Start Predicting' to see predictions,
      and 'Stop Predicting' to end
    </div>
    <button type="button" id="startPredicting" v-on:click="startPredicting">
      Start Predicting
    </button>
    <button type="button" id="stopPredicting" v-on:click="stopPredicting">
      Stop Predicting
    </button>
    <div id="prediction">{{ prediction }}}</div>
  </div>
</template>

<script lang="ts">
import { Webcam } from "@/model/Webcam";
import { Dataset } from "@/model/Dataset";
import { Vue, Component, Prop } from "vue-property-decorator";
import * as tf from "@tensorflow/tfjs";
import { LayersModel, Sequential, Tensor1D, Tensor2D } from "@tensorflow/tfjs";

@Component
export default class WebcamPanel extends Vue {
  private model: LayersModel;
  private mobilenet: LayersModel;

  @Prop() public classNames: Array<string> = ["Rock", "Paper", "Scissors"];
  @Prop() public numSamples: Array<number> = [0, 0, 0];
  public predictionText: string;

  public isPredicting: boolean;
  public dataset: Dataset;
  public webcam: Webcam;

  constructor() {
    super();
    this.isPredicting = false;
    this.dataset = new Dataset();
    this.predictionText = "";
    this.model = new Sequential();
    this.webcam = new Webcam();
    this.mobilenet = new Sequential();
  }

  mounted(): void {
    this.init();
    console.log(tf.getBackend())
  }

  async init(): Promise<void> {
    this.webcam.setWebcamElement(this.$refs.wc);
    this.model = await this.loadMobilenet();
    await this.webcam.setup();
    console.log(this.webcam);
    tf.tidy(() => this.model.predict(this.webcam.capture()));
  }

  async loadMobilenet(): Promise<LayersModel> {
    this.mobilenet = await tf.loadLayersModel(
        "https://storage.googleapis.com/tfjs-models/tfjs/mobilenet_v1_0.25_224/model.json"
    );
    const layer = this.mobilenet.getLayer("conv_pw_13_relu");
    return tf.model({
      inputs: this.mobilenet.inputs,
      outputs: layer.output,
    });
  }

  async train(): Promise<void> {
    this.dataset.ys = null;
    this.dataset.encodeLabels(3);
    console.log(this.model.summary());
    console.log(this.dataset);
    console.log(this.mobilenet.summary());
    this.model = tf.sequential({
      layers: [
        tf.layers.inputLayer({inputShape: this.mobilenet.outputs[0].shape.slice(1)}),
//        tf.layers.flatten(),
        tf.layers.dense({ units: 100, activation: "relu" }),
        tf.layers.dense({ units: 3, activation: "softmax" }),
      ],
    });
    const optimizer = tf.train.adam(0.01);
    this.model.compile({
      optimizer: optimizer,
      loss: "categoricalCrossentropy",
    });
    let loss:string;

    this.model.fit(this.dataset.xs, this.dataset.ys, {
      epochs: 100,
      callbacks: {
      onBatchEnd: async (batch:number, logs: any) => {
        loss = logs.loss.toFixed(5);
        console.log('LOSS: ' + loss);
        }
      }
    });
  }

  doTraining(): void {
    this.train();
  }

  handleButton(id: number): void {
      this.numSamples[id] += 1;
      console.log(this.numSamples)
      const img = this.webcam.capture();
      const features = this.mobilenet.predict(img);
      console.log(features);
      this.dataset.addExample(features, id);
    }

  startPredicting():void {
    this.isPredicting = true;
    this.predict();
  }

  stopPredicting():void {
    this.isPredicting = false;
    this.predict();
  }

  async predict(): Promise<void> {
    while (this.isPredicting) {
      const predictedClass = tf.tidy(() => {
        const img = this.webcam.capture();
        const activation = this.mobilenet.predict(img);
        const predictions:any = this.model.predict(activation);
        return predictions.as1D().argMax();
      });
      const classId = (await predictedClass.data())[0];
      this.predictionText = "I see "+ this.classNames[classId];
      predictedClass.dispose();
      await tf.nextFrame();
    }
  }

  get prediction(){
    return this.predictionText;
  }
}
</script>
