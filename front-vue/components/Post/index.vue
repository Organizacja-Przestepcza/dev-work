<script setup lang="ts">
import type { Post } from '~/common/models';
import { useToast } from "primevue/usetoast";
import dayjs from 'dayjs';

const props = defineProps({
    post: {
        type: Object as PropType<Post>,
        required: true
    }
});
watchEffect(() => {
    console.log(props.post);
})
const activeIndex = ref(0);
const responsiveOptions = ref([
    {
        breakpoint: '768px', // MD (średnie ekrany i większe)
        numVisible: 4
    },
    {
        breakpoint: '575px', // SM (małe ekrany)
        numVisible: 1
    }
]);
const displayCustom = ref(false);

const imageClick = (index: number) => {
    activeIndex.value = index;
    displayCustom.value = true;
};
const likeCount = ref(0);
const dislikeCount = ref(0);
const commentsCount = ref(0);

const isLiked = ref(false);
const isDisliked = ref(false);
const isBookmarked = ref(false);

const toggleLike = () => {
    isLiked.value = !isLiked.value;
    if (isLiked.value) {
        likeCount.value++;
        if (isDisliked.value) {
            isDisliked.value = false;
            dislikeCount.value--;
        }

    }
    else {
        likeCount.value--;
    }
};

const toggleDislike = () => {
    isDisliked.value = !isDisliked.value;
    if (isDisliked.value) {
        dislikeCount.value++;
        if (isLiked.value) {
            isLiked.value = false;
            likeCount.value--;
        }
    }
    else {
        dislikeCount.value--;
    }
};

const toast = useToast();
const toggleBookmark = () => {
    isBookmarked.value = !isBookmarked.value;
    toast.add({ severity: 'info', summary: 'Info', detail: 'Message Content', life: 3000 });
};


</script>

<template>
    <Card style="overflow: hidden">
        <template #content>
            <div class="flex justify-between">
                <button class="flex justify-center items-center">
                    <Avatar size="xlarge"
                        image="https://cdn.prod.website-files.com/5ed475eca0977f7f3f4d7105/5edf22fa1ac939ecdd60632a_Untitled-7_0001_pizzacat-meme1.jpg"
                        class="mr-2" shape="circle" />
                    <span class="inline-flex flex-col items-start">
                        <span class="font-bold">God of this website</span>
                        <span class="text-gray-500">@admin</span>
                    </span>
                </button>
                <span class="text-gray-500">{{ dayjs(post.createdAt).format('HH:mm DD-MM-YYYY') }}</span>
            </div>

            <p class="my-5 mx-2 text-justify">
                {{ post.content }}
            </p>
            <div class="flex items-center ">
                <div class="flex  mx-1">
                    <Galleria v-model:activeIndex="activeIndex" v-model:visible="displayCustom" :value="post.imageUrls"
                        :responsiveOptions="responsiveOptions" :numVisible="7" :circular="true" :fullScreen="true"
                        :showItemNavigators="true" :showThumbnails="false">
                        <template #item="slotProps">
                            <img :src="slotProps.item" :alt="slotProps.item.alt" style="width: 100%; display: block" />
                        </template>
                        <template #thumbnail="slotProps">
                            <img :src="slotProps.item" :alt="slotProps.item.alt" style="display: block" />
                        </template>
                    </Galleria>

                    <div v-if="post.imageUrls" class="flex gap-5 flex-wrap md:flex-nowrap ">
                        <div v-for="(image, index) of post.imageUrls" :key="index" :class="{
                            'w-full': post.imageUrls.length === 1,
                            'w-1/2': post.imageUrls.length === 2,
                            'w-1/3': post.imageUrls.length === 3,
                            'w-1/4': post.imageUrls.length === 4
                        }" class="cursor-pointer" @click="imageClick(index)" >
                            <img :src="image" :alt="image" class="w-full h-48 object-cover rounded-md" />
                        </div>
                    </div>
                </div>
            </div>

        </template>
        <template #footer>
            <div class="flex justify-between">
                <div class="flex gap-3 mx-1 mt-3">

                    <Button severity="secondary" @click="toggleLike">
                        <span :class="isLiked ? 'pi pi-thumbs-up-fill' : 'pi pi-thumbs-up'"
                            style="font-size: 1rem"></span>
                        <Badge :value="likeCount" />
                    </Button>


                    <Button severity="secondary" @click="toggleDislike">
                        <span :class="isDisliked ? 'pi pi-thumbs-down-fill' : 'pi pi-thumbs-down'"
                            style="font-size: 1rem"></span>
                        <Badge :value="dislikeCount" />
                    </Button>

                    <Button severity="secondary">
                        <span :class="'pi pi-comment'" style="font-size: 1rem"></span>
                        <Badge :value="commentsCount" />
                    </Button>


                </div>
                <div class="flex gap-3 mx-1 mt-3">
                    <Button severity="secondary" @click="toggleBookmark">
                        <span :class="isBookmarked ? 'pi pi-bookmark-fill' : 'pi pi-bookmark'"
                            style="font-size: 1rem"></span>
                    </Button>
                </div>
            </div>


        </template>
    </Card>
    <Toast />
</template>