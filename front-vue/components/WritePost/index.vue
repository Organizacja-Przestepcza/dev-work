<script setup lang="ts">
import { type PostRequest, type User } from '~/common/models';

const user = useState<User>('currentUser');
const runtimeConfig = useRuntimeConfig();
const token = useCookie('auth_token').value;
const message = ref('');
const emit = defineEmits(['uploadPost']);
const handlePublishPost = async() =>{
    const post = ref<PostRequest>({
        content: message.value
    });

    const {status} = await useFetch(`${runtimeConfig.public.API_BASE_URL}/posts`,{
        method: 'POST',
        headers: {
            Authorization: `Bearer ${token}`,
        },
        body: post
    });

    if(status.value == 'success'){
       emit('uploadPost');
    }
 
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
                <Button @click="handlePublishPost" label="Publish" />
            </div>

        </template>
    </Card>
</template>