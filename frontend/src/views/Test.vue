<template>
  <button @click="test">Click Me!</button>
</template>

<script>
import Axios from "axios";

export default {
  methods: {
    test: function () {
      console.log("Test");
      Axios.get("https://localhost:5001/api/users").then((response) => {
        console.log(response.data);
      });
    },
  },
};
</script>
