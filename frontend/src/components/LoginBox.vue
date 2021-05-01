<template>
    <div class="min-h-screen bg-gray-50 flex flex-col justify-center">
        <div class="max-w-nd w-full mx-auto">
            <div class="text-center font-bold mt-2 mb-8 text-7xl"> Welcome to CollabTag.ai </div>
        </div>
        
        <div class="max-w-nd mx-auto w-1/4 mt-4 bg-white p-8 border rounded-xl border-gray-300">
            <form action="">
                <div>
                    <label class="text-m font-bold text-gray-600 block"> Username: </label>
                    <input type="text" class="block w-full p-2 rounded border-2 border-solid border-gray-500">
                </div>
                <div class="mt-5">
                    <label class="text-m font-bold text-gray-600 block"> Password: </label>
                    <input type="password" class="block w-full p-2 rounded border-2 border-solid border-gray-500">
                </div>
                <div class="mt-10 flex justify-center">
                    <button class=" w-1/4 py-2 px-4 bg-blue-500 hover:bg-blue-600 rounded-md text-white flex justify-center">Login</button>
                    <!-- <input type="submit" value="Login" class="py-3 bg-green-500 text-m font-bold text-white w-full rounded hover:bg-green-600"> -->
                </div>
                <div class="mt-5 flex justify-center">
                    <p class="pr-1"> Don't have an account? </p>
                    <a href="" class="font-medium text-blue-500">create one</a>
                </div>
            </form>
        </div>
    </div>
</template>

<script lang="ts">
import Vue from 'vue'
export default Vue.extend({
    name: 'LoginBox',

    data: () => ({

    }),
})
</script>