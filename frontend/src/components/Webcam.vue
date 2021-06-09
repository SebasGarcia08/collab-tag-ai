<template>
  <div class="float-center md:float-center">
    <div class="flex justify-center">
      <video
        autoplay
        playsinline
        muted
        ref="wc"
        width="600"
        height="600"
      ></video>
    </div>

    <!-- Classes buttons -->
    <!-- <div class="flex items-center justify-center border-4">
      <div class="grid grid-flow-row grid-cols-3 gap-2 items-center justify-center">
        <div class="px-1" v-for="(pjClass, idx) in classes" :key="idx">
          <button class="py-2 w-32 px-4 bg-blue-500 hover:bg-blue-600 rounded-md text-white" 
          @click="handleButton(idx)"> {{ pjClass }} [{{ classCounter[idx] }}] </button>
        </div>
      </div>
    </div> -->

    <div
      class="flex items-center justify-center"
      v-for="(i, idxI) in Math.ceil(classes.length / 3)"
      :key="idxI"
    >
      <div
        class="p-1"
        v-for="(pjClass, idxJ) in classes.slice((i - 1) * 3, i * 3)"
        :key="idxJ"
      >
        <button
          class="py-2 w-32 px-4 bg-blue-500 hover:bg-blue-600 rounded-md text-white"
          @click="handleButton(idxJ + idxI * 3)"
        >
          {{ pjClass.name }} [{{ classCounter[idxJ + idxI * 3] }}]
        </button>
      </div>
    </div>

    <div class="flex justify-center">
      <button
        class="w-1/4 py-2 px-4 bg-green-500 hover:bg-green-600 rounded-md text-white flex justify-center"
        v-on:click="doTraining"
      >
        Train Network
      </button>
    </div>
    <div class="flex justify-center">
      Once training is complete, click 'Start Predicting' to see predictions,
      and 'Stop Predicting' to end
    </div>
    <div class="flex justify-center">
      <button
        class="w-1/4 py-2 px-4 bg-green-500 hover:bg-green-600 rounded-md text-white flex justify-center"
        id="startPredicting"
        v-on:click="startPredicting"
      >
        Start Predicting
      </button>
      <button
        class="w-1/4 py-2 px-4 bg-red-500 hover:bg-red-600 rounded-md text-white flex justify-center"
        id="stopPredicting"
        v-on:click="stopPredicting"
      >
        Stop Predicting
      </button>
      <div id="prediction">{{ prediction }}</div>
    </div>
  </div>
</template>

<script lang="ts">
import { Webcam } from "@/model/Webcam";
import { Dataset } from "@/model/Dataset";
import { Vue, Component, Prop } from "vue-property-decorator";
import * as tf from "@tensorflow/tfjs";
import * as tfvis from "@tensorflow/tfjs-vis";
import { LayersModel, Sequential } from "@tensorflow/tfjs";
import store from "../model/Store";

@Component
export default class WebcamPanel extends Vue {
  classes = store.currentProject.classes;
  classCounter = new Array(this.classes.length).fill(0);

  private model: LayersModel;
  private mobilenet: LayersModel;

  public classNames: Array<string> = ["Rock", "Paper", "Scissors"];
  public numSamples: Array<number>;
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
    this.numSamples = [0, 0, 0];
  }

  mounted(): void {
    this.init();
    console.log(tf.getBackend());
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
        tf.layers.inputLayer({
          inputShape: this.mobilenet.outputs[0].shape.slice(1),
        }),
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
    let loss: string;
    const surface = { name: "show.fitCallbacks", tab: "Training" };
    this.model.fit(this.dataset.xs, this.dataset.ys, {
      epochs: 50,
      callbacks: tfvis.show.fitCallbacks(surface, ["loss", "acc"]),
      //      onBatchEnd: async (batch:number, logs: any) => { loss = logs.loss.toFixed(5); console.log('LOSS: ' + loss); },
    });
  }

  doTraining(): void {
    this.train();
  }

  handleButton(id: number): void {
    Vue.set(this.classCounter, id, this.classCounter[id] + 1);
    console.log(id);
    console.log(this.classCounter);
    const img = this.webcam.capture();
    const features = this.mobilenet.predict(img);
    console.log(features);
    this.dataset.addExample(features, id);
  }

  startPredicting(): void {
    this.isPredicting = true;
    this.predict();
  }

  stopPredicting(): void {
    this.isPredicting = false;
    this.predict();
  }

  async predict(): Promise<void> {
    while (this.isPredicting) {
      const predictedClass = tf.tidy(() => {
        const img = this.webcam.capture();
        const activation = this.mobilenet.predict(img);
        const predictions: any = this.model.predict(activation);
        return predictions.as1D().argMax();
      });
      const classId = (await predictedClass.data())[0];
      this.predictionText = "I see " + this.classNames[classId];
      predictedClass.dispose();
      await tf.nextFrame();
    }
  }

  get prediction() {
    return this.predictionText;
  }
}
</script>
