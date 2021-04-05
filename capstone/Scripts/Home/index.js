import Vue from "vue";
import ModelComponent from "./home.vue"
import ContactComponent from "./contactus.vue"
import AboutUsComponent  from './aboutus.vue'

new Vue({
    el: "#app",
    components:{
        ModelComponent,
        ContactComponent,
        AboutUsComponent
    }
})