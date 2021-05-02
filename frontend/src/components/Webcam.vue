<template>
  <div>
    <div>
      <div>
        <video
          autoplay
          playsinline
          muted
          ref="wc"
          width="224"
          height="224"
        ></video>
      </div>
    </div>
    <button type="button" id="0" v-on:click="handleButton(this)">Rock</button>
    <button type="button" id="1" v-on:click="handleButton(this)">Paper</button>
    <button type="button" id="2" v-on:click="handleButton(this)">
      Scissors
    </button>
    <div>{{ samples["rock"] }}}</div>
    <div>{{ samples["paper"] }}}</div>
    <div>{{ samples["scissors"] }}:</div>
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
    <div id="prediction">{{ predictionText }}}</div>
  </div>
</template>

<script lang="ts">
import { Webcam } from "@/model/Webcam";
import { Dataset } from "@/model/Dataset";
import { Vue, Component, Prop } from "vue-property-decorator";
import * as tf from "@tensorflow/tfjs";
import { LayersModel, Sequential } from "@tensorflow/tfjs";

@Component
export default class WebcamPanel extends Vue {
  private model: LayersModel;
  private mobilenet: LayersModel;

  @Prop() public samples: Record<string, number> = {
    rock: 0,
    paper: 0,
    scissors: 0,
  };
  @Prop() public predictionText: string;

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
    this.model = tf.sequential({
      layers: [
        tf.layers.flatten({
          inputShape: this.model.outputs[0].shape.slice(1),
        }),
        tf.layers.dense({ units: 100, activation: "relu" }),
        tf.layers.dense({ units: 3, activation: "softmax" }),
      ],
    });
    const optimizer = tf.train.adam(0.0001);
    this.model.compile({
      optimizer: optimizer,
      loss: "categoricalCrossentropy",
    });
    let loss = 0;

    this.model.fit(this.dataset.xs, this.dataset.ys, {
      epochs: 10,
    });
  }

  doTraining(): void {
    this.train();
  }
}
</script>
