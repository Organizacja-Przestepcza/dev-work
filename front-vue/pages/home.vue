<script setup lang="ts">
import type { Contact } from '~/common/models';


const viewport = useViewport();

watch(viewport.breakpoint, (newBreakpoint, oldBreakpoint) => {
    if (viewport.isLessThan('tablet')) {
        setPageLayout('mobile');
    } else {
        setPageLayout('default');
    }
});

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
</script>

<template>
    <div class="flex w-5/6 mx-auto gap-5 py-5">
        <div class="w-1/5">
            <PostFilterPanel />
        </div>
        <div class="w-3/5">
           <Post />
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
