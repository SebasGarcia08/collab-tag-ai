<template>
    <button @click="onClick" class="rounded-md text-white text-2xl focus:outline-none">
        {{ text }}
    </button>
</template>

<script lang="ts">
import Vue from "vue";
import Component from "vue-class-component";
import { Prop } from 'vue-property-decorator';

// The @Component decorator indicates the class is a Vue component
@Component({
  components: {

  },
})
export default class Projects extends Vue {
  // Initial data can be declared as instance properties

  @Prop({default: 'Button'}) text!: string

  onClick () {
      this.$emit('toggle-add-project');
  }

}
</script>