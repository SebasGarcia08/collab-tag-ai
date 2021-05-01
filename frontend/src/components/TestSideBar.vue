<template>
        <nav class="navbar group-foo fized w-20 h-screen bg-blue-400 hover:w-56 duration-200 ease-in">
            <ul class="navbar-nav p-0 m-0 h-screen flex flex-col items-center">
                <div v-for="button in buttons" v-bind:key="button">
                    <SideBarButton buttonLabel="button.label" route="button.route" icon="button.icon" />
                </div>

                <!-- Projects button -->
                <SideBarButton buttonLabel="Projects" route="/Porjects" icon="fas fa-stream fa-2x" />

                <!-- Settings button -->
                <li class="nav-item w-full group-bar">
                    <a href="#" class="nav-link flex items-center h-20 no-underline duration-200 hover:bg-blue-600">
                        <!-- Insert icon/image here -->
                        <i class="fas fa-cogs fa-2x w-8 m-6 text-blue-900 group-bar-hover:text-white"></i>
                        <span class="link-text hidden m-4 group-foo-hover:block font-bold text-blue-900 text-xl group-bar-hover:text-white"> Settings </span>
                    </a>
                </li>

                <!-- Log out button -->
                <li class="nav-item w-full mt-auto group-bar">
                    <a href="#" class="nav-link flex items-center h-20 no-underline duration-200 hover:bg-blue-600">
                        <!-- Insert icon/image here -->
                        <i class="fas fa-sign-out-alt fa-2x min-w-8 m-6 text-blue-900 group-bar-hover:text-white"></i>
                        <span class="link-text hidden m-4 group-foo-hover:block font-bold text-blue-900 text-xl group-bar-hover:text-white"> Log out </span>
                    </a>
                </li>
            </ul>
        </nav>
</template>

<script lang="ts">
import Vue from 'vue'
import SideBarButton from './SideBarButton.vue'
export default Vue.extend({
    name: 'SideBar',
    components: {
        SideBarButton
    },
    props: {
        buttons: Array
    },
    data: () => ({

    }),
})
</script>