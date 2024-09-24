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
        commentCount: '1'
    }
},
{
    user: {
        avatar: 'https://tr.rbxcdn.com/42eb7f0fcc6028fc0c5a23bc45419d37/420/420/Hat/Webp',
        username: 'Catissimo Cato',
        displayname: 'CatBoss69'
    },
    post: {
        id: '3',
        content: 'Second comment here',
        createdAt: new Date(),
        commentCount: '1'
    }
},
{
    user: {
        avatar: 'https://tr.rbxcdn.com/42eb7f0fcc6028fc0c5a23bc45419d37/420/420/Hat/Webp',
        username: 'Catissimo Cato',
        displayname: 'CatBoss69'

    },
    post: {
        id: '2',
        content: 'Third comment here',
        createdAt: new Date(),
        commentCount: '1'
    }
}
]);
</script>
<template>
    <div>
        <div v-if="comments && comments.length > 0" class="flex flex-col gap-5 text-center ">

            <div v-for="comment in comments">
                <span class="w-full text-gray-500 pb-5 pi pi-ellipsis-v"></span>
                <Post :post="comment.post" class="w-full" />
            </div>


        </div>
        <div v-else>
            <span>No contacts found.</span>
        </div>

    </div>
</template>
