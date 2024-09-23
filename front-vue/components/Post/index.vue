<script setup lang="ts">
import type { Post } from '~/common/models';
const props = defineProps({
  post: {
    type: Object as PropType<Post>,
    required: true
  }
});

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

const toggleBookmark = () => {
    isBookmarked.value = !isBookmarked.value;
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
                <span>{{ post.CreatedAt }}</span>
            </div>

            <p class="my-5 mx-2 text-justify">
                {{ post.Content }}
            </p>
            <div class="flex items-center justify-center">
                <div class="flex justify-center mx-1">
                    <Galleria v-model:activeIndex="activeIndex" v-model:visible="displayCustom" :value="post.ImageUrls"
                        :responsiveOptions="responsiveOptions" :numVisible="7" :circular="true" :fullScreen="true"
                        :showItemNavigators="true" :showThumbnails="false">
                        <template #item="slotProps">
                            <img :src="slotProps.item" :alt="slotProps.item.alt"
                                style="width: 100%; display: block" />
                        </template>
                        <template #thumbnail="slotProps">
                            <img :src="slotProps.item" :alt="slotProps.item.alt"
                                style="display: block" />
                        </template>
                    </Galleria>

                    <div v-if="post.ImageUrls" class="flex gap-5 flex-wrap md:flex-nowrap">
                        <div v-for="(image, index) of post.ImageUrls" :key="index" class="cursor-pointer w-full md:w-1/4"
                            @click="imageClick(index)">
                            <img :src="image" :alt="image" class="w-full rounded-md" />
                        </div>
                    </div>
                </div>
            </div>

        </template>
        <template #footer>
            <div class="flex gap-3 mx-1 mt-3">

                <Button severity="secondary" @click="toggleLike">
                    <span :class="isLiked ? 'pi pi-thumbs-up-fill' : 'pi pi-thumbs-up'" style="font-size: 1rem"></span>
                    <Badge :value="likeCount" />
                </Button>


                <Button severity="secondary" @click="toggleDislike">
                    <span :class="isDisliked ? 'pi pi-thumbs-down-fill' : 'pi pi-thumbs-down'"
                        style="font-size: 1rem"></span>
                    <Badge :value="dislikeCount" />
                </Button>

                <Button severity="secondary">
                    <span :class="'pi pi-comment'"
                        style="font-size: 1rem"></span>
                        <Badge :value="commentsCount" />
                </Button>

                <Button severity="secondary" @click="toggleBookmark">
                    <span :class="isBookmarked ? 'pi pi-bookmark-fill' : 'pi pi-bookmark'"
                        style="font-size: 1rem"></span>
                </Button>
            </div>
            
        </template>
    </Card>

</template>