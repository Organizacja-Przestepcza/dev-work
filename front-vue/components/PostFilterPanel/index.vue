<script setup lang="ts">
const activeButton = ref('For you');

const setActiveButton = (label: string) => {
    activeButton.value = label;
};
</script>
<template>
     <div class="flex flex-col gap-5 w-full">
        <Button :severity="activeButton === 'For you' ? 'success' : 'secondary'" @click="setActiveButton('For you')"
                icon="pi pi-heart" label="For you" />

            <Button :severity="activeButton === 'Trending' ? 'success' : 'secondary'"
                @click="setActiveButton('Trending')" icon="pi pi-chart-lines" label="Trending" />

            <Button :severity="activeButton === 'Latest' ? 'success' : 'secondary'" @click="setActiveButton('Latest')"
                icon="pi pi-star" label="Latest" />


            <Button :severity="activeButton === 'Bookmarks' ? 'success' : 'secondary'"
                @click="setActiveButton('Bookmarks')" icon="pi pi-bookmark" label="Bookmarks" />

     </div>
           

       
</template>