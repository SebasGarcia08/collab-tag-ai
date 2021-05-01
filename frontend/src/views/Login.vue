<template>
    <div class="container relative">
        <SideBar class="absolute"/>
        <LoginBox />
    </div>
</template>

<script lang="ts">
import Vue from 'vue'
import LoginBox from "../components/LoginBox.vue";
import SideBar from "../components/SideBar.vue";
export default Vue.extend({
    name: 'Login',

    components: {
        LoginBox,
        SideBar,
    },

    data: () => ({

    }),
})
</script>