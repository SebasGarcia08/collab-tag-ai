/*
export default Vue.extend({
  name: "Webcam",
  data() {
    return {
      rockSamples: 0,
      paperSamples: 0,
      scissorsSamples: 0,
      isPredicting: false,
      mobilenet: null,
      model: null,
      predictionText: "",
      webcam: new Webcam(this.$refs.wc),
      dataset: new Dataset(),
    };
  },
  methods: {
    init: async () => {
      console.log(this);
      await this.webcam.setup();
      this.model = await this.loadMobilenet();
      tf.tidy(() => this.model.predict(this.webcam.capture()));
    },

    loadMobilenet: async () => {
      this.mobilenet = await tf.loadLayersModel(
        "https://storage.googleapis.com/tfjs-models/tfjs/mobilenet_v1_0.25_224/model.json"
      );
      const layer = this.mobilenet.getLayer("conv_pw_13_relu");
      return tf.model({
        inputs: this.mobilenet.inputs,
        outputs: layer.output,
      });
    },

    doTraining: () => {
      this.train();
    },

    startPredicting: () => {
      this.isPredicting = true;
      this.predict();
    },

    train: async () => {
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
        callbacks: {
          onBatchEnd: async (batch, logs) => {
            loss = logs.loss.toFixed(5);
            console.log("LOSS: " + loss);
          },
        },
      });
    },

    handleButton: (elem) => {
      switch (elem.id) {
        case "0":
          this.rockSamples++;
          break;
        case "1":
          this.paperSamples++;
          break;
        case "2":
          this.scissorsSamples++;
          break;
      }
      var label = parseInt(elem.id);
      const img = this.webcam.capture();
      this.dataset.addExample(this.mobilenet.predict(img), label);
    },

    predict: async () => {
      while (this.isPredicting) {
        const predictedClass = tf.tidy(() => {
          const img = this.webcam.capture();
          const activation = this.mobilenet.predict(img);
          const predictions = this.model.predict(activation);
          return predictions.as1D().argMax();
        });
        const classId = (await predictedClass.data())[0];
        switch (classId) {
          case 0:
            this.predictionText = "I see Rock";
            break;
          case 1:
            this.predictionText = "I see Paper";
            break;
          case 2:
            this.predictionText = "I see Scissors";
            break;
        }
        predictedClass.dispose();
        await tf.nextFrame();
      }
    },
  },
});
*/

/*
let mobilenet;
let model;
const webcam = new Webcam(document.getElementById("wc"));
const dataset = new Dataset();

var rockSamples = 0,
  paperSamples = 0,
  scissorsSamples = 0;
let isPredicting = false;

async function loadMobilenet() {
  const mobilenet = await tf.loadLayersModel(
    "https://storage.googleapis.com/tfjs-models/tfjs/mobilenet_v1_0.25_224/model.json"
  );
  const layer = mobilenet.getLayer("conv_pw_13_relu");
  return tf.model({ inputs: mobilenet.inputs, outputs: layer.output });
}

async function train() {
  dataset.ys = null;
  dataset.encodeLabels(3);
  model = tf.sequential({
    layers: [
      tf.layers.flatten({ inputShape: mobilenet.outputs[0].shape.slice(1) }),
      tf.layers.dense({ units: 100, activation: "relu" }),
      tf.layers.dense({ units: 3, activation: "softmax" }),
    ],
  });
  const optimizer = tf.train.adam(0.0001);
  model.compile({ optimizer: optimizer, loss: "categoricalCrossentropy" });
  let loss = 0;
  model.fit(dataset.xs, dataset.ys, {
    epochs: 10,
    callbacks: {
      onBatchEnd: async (batch, logs) => {
        loss = logs.loss.toFixed(5);
        console.log("LOSS: " + loss);
      },
    },
  });
}

function handleButton(elem) {
  switch (elem.id) {
    case "0":
      rockSamples++;
      document.getElementById("rocksamples").innerText =
        "Rock samples:" + rockSamples;
      break;
    case "1":
      paperSamples++;
      document.getElementById("papersamples").innerText =
        "Paper samples:" + paperSamples;
      break;
    case "2":
      scissorsSamples++;
      document.getElementById("scissorssamples").innerText =
        "Scissors samples:" + scissorsSamples;
      break;
  }
  var label = parseInt(elem.id);
  const img = webcam.capture();
  dataset.addExample(mobilenet.predict(img), label);
}

async function predict() {
  while (isPredicting) {
    const predictedClass = tf.tidy(() => {
      const img = webcam.capture();
      const activation = mobilenet.predict(img);
      const predictions = model.predict(activation);
      return predictions.as1D().argMax();
    });
    const classId = (await predictedClass.data())[0];
    var predictionText = "";
    switch (classId) {
      case 0:
        predictionText = "I see Rock";
        break;
      case 1:
        predictionText = "I see Paper";
        break;
      case 2:
        predictionText = "I see Scissors";
        break;
    }
    document.getElementById("prediction").innerText = predictionText;

    predictedClass.dispose();
    await tf.nextFrame();
  }
}

function doTraining() {
  train();
}

function startPredicting() {
  isPredicting = true;
  predict();
}

function stopPredicting() {
  isPredicting = false;
  predict();
}

async function init() {
  await webcam.setup();
  mobilenet = await loadMobilenet();
  tf.tidy(() => mobilenet.predict(webcam.capture()));
}

init();
 */
