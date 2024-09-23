<script setup lang="ts">
import type { Contact, Post } from '~/common/models';

definePageMeta({
    middleware: 'auth'
});

const viewport = useViewport();


const contacts = ref<Contact[]>([
    {
        avatar: 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSXx2xFk_wEb1hLQoDo4Ar3YbhosCPyOCfOgA&s',
        username: 'Catto Catoni'
    },
    {
        avatar: 'https://cdn.prod.website-files.com/5ed475eca0977f7f3f4d7105/5edf22fa1ac939ecdd60632a_Untitled-7_0001_pizzacat-meme1.jpg',
        username: 'Catissimo Catani'
    },
    {
        avatar: 'https://tr.rbxcdn.com/31b116ca0b953b6f5565319800bab4be/420/420/Hat/Webp',
        username: 'Kitto Katto'
    }
]);

const token = useCookie('auth_token').value;
const { status, data: posts } = useFetch('http://localhost:5151/api/post', {
    headers: {
        Authorization: `Bearer ${token}` // Dodaj token JWT do nagłówka
    },
    lazy: true
});


</script>

<template>
    <div class="flex w-5/6 mx-auto gap-5 py-5">
        <div class="w-1/5">
            <PostFilterPanel />
        </div>
        <div class="w-3/5">
            <div v-if="status === 'pending'">
                Loading ...
            </div>

            <div class="flex flex-col gap-5" v-else >
                <Post v-for="post in posts" :post="post" />
            </div>

        </div>
        <div class="w-1/5 flex flex-wrap gap-5">
            <Card>
                <template #title>Chats</template>
                <template #content>
                    <p class="m-0">
                        Lorem ipsum dolor sit amet, consectetur adipisicing elit. Inventore sed consequuntur error
                        repudiandae numquam deserunt quisquam repellat libero asperiores earum nam nobis, culpa ratione
                        quam perferendis esse, cupiditate neque quas!
                    </p>
                </template>
            </Card>

            <Card class="w-full">
                <template #title>Contacts</template>
                <template #content>
                    <ContactTile :contacts="contacts" />
                </template>
            </Card>


        </div>
    </div>
</template>
