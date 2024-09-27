<script setup lang="ts">
import { ref, onMounted } from 'vue';
import {useFetch, useRuntimeConfig, useCookie } from '#imports';
import type{ User, Bookmark, Post } from '~/common/models';
import dayjs from 'dayjs';


const emit = defineEmits(['bookmarkClick']);
const props = defineProps({
    post: {
        type: Object as PropType<Post>,
        required: true
    }
});

const imageClick = (index: number) => {
    activeIndex.value = index;
    displayCustom.value = true;
};


const activeIndex = ref(0);
const displayCustom = ref(false);
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

const likeCount = ref(0);
const dislikeCount = ref(0);
const commentsCount = ref(Number(props.post.commentCount) ?? 0);

const isLiked = ref(false);
const isDisliked = ref(false);
const isBookmarked = ref(false);

const runtimeConfig = useRuntimeConfig();
const token = useCookie('auth_token').value;

const fetchBookmarks = async () => {
    const {data, status, error} = await useFetch(`${runtimeConfig.public.API_BASE_URL}/bookmarks/${props.post.id}`, {
        method: 'GET',
        headers: {
            Authorization: `Bearer ${token}`
        },
    });

    if (status.value === 'success') {
        isBookmarked.value = true;
    } else if (status.value === 'error') {
        isBookmarked.value = false;

    }
};


onNuxtReady(() => {
    fetchBookmarks();
});


const toggleLike = () => {
    isLiked.value = !isLiked.value;
    if (isLiked.value) {
        likeCount.value++;
        if (isDisliked.value) {
            isDisliked.value = false;
            dislikeCount.value--;
        }
    } else {
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
    } else {
        dislikeCount.value--;
    }
};


const toggleBookmark = async () => {
    const methodAction = isBookmarked.value ? 'DELETE' : 'POST';
    const url = `${runtimeConfig.public.API_BASE_URL}/bookmarks/${props.post.id}`;

    try {
        const { status, error } = await useFetch(url, {
            method: methodAction,
            headers: {
                Authorization: `Bearer ${token}`,
                'Content-Type': 'application/json',
            },
        });

       
        if (status.value === 'success') {
            isBookmarked.value = !isBookmarked.value; 
            emit('bookmarkClick', status.value, isBookmarked.value);
        } else {
            console.error('Error toggling bookmark:', error.value);
        }
    } catch (err) {
        console.error('Fetch error:', err);
    }
};
const user = useState<User>('currentUser');

</script>

<template>
    <Card style="overflow: hidden">
        <template #content>
            <div class="flex justify-between">
               <UserTile :user="props.post.user"/>
                <span class="text-gray-500">{{ dayjs(props.post.createdAt).format('HH:mm DD-MM-YYYY') }}</span>
            </div>

            <p class="my-5 mx-2 text-justify">
                {{ props.post.content }}
            </p>
            <div class="flex items-center ">
                <div class="flex mx-1">
                    <Galleria v-model:activeIndex="activeIndex" v-model:visible="displayCustom" :value="props.post.imageUrls"
                        :responsiveOptions="responsiveOptions" :numVisible="7" :circular="true" :fullScreen="true"
                        :showItemNavigators="true" :showThumbnails="false">
                        <template #item="slotProps">
                            <img :src="slotProps.item" :alt="slotProps.item.alt" style="width: 100%; display: block" />
                        </template>
                        <template #thumbnail="slotProps">
                            <img :src="slotProps.item" :alt="slotProps.item.alt" style="display: block" />
                        </template>
                    </Galleria>

                    <div v-if="props.post.imageUrls" class="flex gap-5 flex-wrap md:flex-nowrap ">
                        <div v-for="(image, index) of props.post.imageUrls" :key="index" :class="{
                            'w-full': props.post.imageUrls.length === 1,
                            'w-1/2': props.post.imageUrls.length === 2,
                            'w-1/3': props.post.imageUrls.length === 3,
                            'w-1/4': props.post.imageUrls.length === 4
                        }" class="cursor-pointer" @click="imageClick(index)">
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
                        <span :class="isLiked ? 'pi pi-thumbs-up-fill' : 'pi pi-thumbs-up'" style="font-size: 1rem"></span>
                        <Badge :value="likeCount" />
                    </Button>

                    <Button severity="secondary" @click="toggleDislike">
                        <span :class="isDisliked ? 'pi pi-thumbs-down-fill' : 'pi pi-thumbs-down'" style="font-size: 1rem"></span>
                        <Badge :value="dislikeCount" />
                    </Button>

                    <Button severity="secondary" @click="navigateTo('/posts/' + props.post.id)">
                        <span :class="'pi pi-comment'" style="font-size: 1rem"></span>
                        <Badge :value="commentsCount" />
                    </Button>
                </div>
                <div class="flex gap-3 mx-1 mt-3">
                    <Button severity="secondary" @click="toggleBookmark">
                        <span :class="isBookmarked ? 'pi pi-bookmark-fill' : 'pi pi-bookmark'" style="font-size: 1rem"></span>
                    </Button>
                </div>
            </div>
        </template>
    </Card>
    <Toast />
</template>
