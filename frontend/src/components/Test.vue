<template>
    <div class="div">
        <h1>{{ greeting }}</h1>
        <button @click="init()">INCREMENT ME</button>
        <br>
        <input @change="predict()" type="text">
    </div>
</template>

<script lang="ts">
import {Vue, Component} from 'vue-property-decorator';
@Component
export default class Test extends Vue {
    public greeting: string;

    constructor(){
        super();
        this.greeting = "Unchanged"
        this.init();
    } 
    
    init(): void{
        this.greeting = "This has been foking initialized";
    }

    predict(): void{
        this.greeting = "I am here"
        console.log("PREDIIIIIIIIIIIICT")
    }
}
</script>