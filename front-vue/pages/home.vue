<script setup lang="ts">

const viewport = useViewport()

watch(viewport.breakpoint, (newBreakpoint, oldBreakpoint) => {
    if (viewport.isLessThan('tablet')) {
        setPageLayout('mobile');
    }
    else {
        setPageLayout('default');
    }
});


</script>
<template>
    <div class="flex w-5/6 mx-auto gap-5 py-5">
        <div class=" w-1/5 ">
            <PostFilterPanel/>
        </div>
            <div class="w-3/5 ">
                <Card style=" overflow: hidden">
                    <template #header>
                        <img alt="user header" height="5rem" src="../assets/img/logo.svg" />
                    </template>
                    <template #title>Advanced Card</template>
                    <template #subtitle>Card subtitle</template>
                    <template #content>
                        <p class="m-0">
                            Lorem ipsum dolor sit amet, consectetur adipisicing elit. Inventore sed consequuntur error
                            repudiandae numquam deserunt quisquam repellat libero asperiores earum nam nobis, culpa
                            ratione
                            quam perferendis esse, cupiditate neque
                            quas!
                        </p>
                    </template>
                </Card>
            </div>
        
        <div class="w-1/5 flex flex-wrap gap-5 ">
            <Card>
                <template #title>Chats</template>
                <template #content>
                    <p class="m-0">
                        Lorem ipsum dolor sit amet, consectetur adipisicing elit. Inventore sed consequuntur error
                        repudiandae numquam deserunt quisquam repellat libero asperiores earum nam nobis, culpa ratione
                        quam perferendis esse, cupiditate neque
                        quas!
                    </p>
                </template>
            </Card>
            <Card class="w-full">
                <template #title>Contacts</template>
                <template #content>
                    <button v-ripple
                        class="relative overflow-hidden w-full border-0 bg-transparent flex items-start p-2 pl-4 hover:bg-surface-100 dark:hover:bg-surface-800 rounded-none cursor-pointer transition-colors duration-200">
                        <Avatar image="https://primefaces.org/cdn/primevue/images/avatar/amyelsner.png" class="mr-2"
                            shape="circle" />
                        <span class="inline-flex flex-col items-start">
                            <span class="font-bold">Amy Elsner</span>
                            <span class="text-sm">Admin</span>
                        </span>
                    </button>
                </template>
            </Card>
        </div>
    </div>
</template>
