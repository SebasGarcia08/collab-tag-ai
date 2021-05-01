<template>
    <div class="container relative">
        <SideBar class="absolute"/>
        <main class="ml-20">
            <h1 class="text-8xl p-10"> Projects </h1>
            <ProjectPreview projectName="Project Name" class="pl-10"/>
        </main>
    </div>
</template>

<script lang="ts">
import Vue from 'vue'
import SideBar from "../components/SideBar.vue"
import ProjectPreview from "../components/ProjectPreview.vue";
export default Vue.extend({
    name: 'Login',

    components: {
        SideBar,
        ProjectPreview,
    },

    data: () => ({

    }),
})
</script>