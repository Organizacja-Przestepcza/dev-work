<script setup lang="ts">
import Drawer from 'primevue/drawer';
import 'primeicons/primeicons.css'
const visible = ref(false);
</script>

<template>
    <div class="flex">
        <div class="card flex justify-center m-5 absolute">
            <Drawer v-model:visible="visible" header="Menu">
                <p>Lorem ipsum.</p>
            </Drawer>
            <Button icon="pi pi-bars" @click="visible = true" />
        </div>


        <!-- Main area -->
        <div class="flex-grow p-4 text-center">
            <slot />
        </div>

        <!-- Right panel (for friends)-->
        <div class="hidden w-1/5 p-4 h-screen justify-center">
            <p>This is the right panel.</p>
        </div>
    </div>
</template>