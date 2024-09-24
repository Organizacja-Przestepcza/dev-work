<script setup lang="ts">
import dayjs from 'dayjs';
import type { Comment } from '~/common/models';

const comments = ref<Comment[]>([{
    user: {
        avatar: 'https://tr.rbxcdn.com/42eb7f0fcc6028fc0c5a23bc45419d37/420/420/Hat/Webp',
        username: 'Catissimo Cato',
        displayname: 'CatBoss69'
    },
    post: {
        id: '1',
        content: 'Comment here',
        createdAt: new Date(),
    }
}]);
</script>
<template>
<div class="flex flex-col gap-5 my-3">
    <Card v-if="comments && comments.length > 0">
        <template #content>
            <div v-for="comment in comments" >
            <button 
            class="relative overflow-hidden w-full border-0 bg-transparent flex items-start p-2 pl-4 hover:bg-surface-100 dark:hover:bg-surface-800 rounded-none cursor-pointer transition-colors duration-200">
            <Avatar :image="comment.user.avatar" class="mr-2" shape="circle" />
            <span class="inline-flex flex-col items-start">
                <span class="font-bold">{{ comment.user.username }}</span>
            </span>
        </button>

        <div>
            {{ comment.post.content }}
        </div>
    </div>
        </template>
        
    </Card>    
    <div v-else>
        <span>No contacts found.</span>
    </div>

</div>
</template>
