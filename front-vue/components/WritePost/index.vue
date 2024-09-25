<script setup lang="ts">
import type { User } from '~/common/models';

const user = ref<User>({
    avatar: 'https://cdn.prod.website-files.com/5ed475eca0977f7f3f4d7105/5edf22fa1ac939ecdd60632a_Untitled-7_0001_pizzacat-meme1.jpg',
    username: 'admin',
    displayname: 'God of this Website'
});

const message = ref('');
const handlePuslishPost = () =>{
    
}
</script>

<template>
    <Card>
        <template #header>
            <h1 class="text-2xl font-bold py-2 px-10">
                Write what's on your mind...
            </h1>

        </template>
        <template #content>
            <div class="flex flex-col gap-5 justify-start ">
                <UserTile :user="user" />
                <Textarea v-model="message" rows="5" cols="30" />
                <Button @click="handlePuslishPost" label="Publish" />
            </div>

        </template>
    </Card>
</template>