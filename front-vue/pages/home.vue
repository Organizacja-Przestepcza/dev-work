<script setup>

const viewport = useViewport()
watch(viewport.breakpoint, (newBreakpoint, oldBreakpoint) => {
    if (viewport.isLessThan('tablet')) {
        setPageLayout('mobile');
    }
    else {
        setPageLayout('default');
    }
})
</script>
<template>
    <div class="flex w-5/6 mx-auto gap-5 py-5">
        <div class="flex flex-wrap gap-5 w-1/5 ">

            <Card>
                <template #title>Simple Card</template>
                <template #content>
                    <p class="m-0">
                        Lorem ipsum dolor sit amet, consectetur adipisicing elit. Inventore sed consequuntur error
                        repudiandae numquam deserunt quisquam repellat libero asperiores earum nam nobis, culpa ratione
                        quam perferendis esse, cupiditate neque
                        quas!
                    </p>
                </template>
            </Card>
            <Card>
                <template #title>Simple Card</template>
                <template #content>
                    <p class="m-0">
                        Lorem ipsum dolor sit amet, consectetur adipisicing elit. Inventore sed consequuntur error
                        repudiandae numquam deserunt quisquam repellat libero asperiores earum nam nobis, culpa ratione
                        quam perferendis esse, cupiditate neque
                        quas!
                    </p>
                </template>
            </Card>

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
                        repudiandae numquam deserunt quisquam repellat libero asperiores earum nam nobis, culpa ratione
                        quam perferendis esse, cupiditate neque
                        quas!
                    </p>
                </template>
            </Card>
        </div>
        <div class="w-1/5 ">
            <Card>
                <template #title>Simple Card</template>
                <template #content>
                    <p class="m-0">
                        Lorem ipsum dolor sit amet, consectetur adipisicing elit. Inventore sed consequuntur error
                        repudiandae numquam deserunt quisquam repellat libero asperiores earum nam nobis, culpa ratione
                        quam perferendis esse, cupiditate neque
                        quas!
                    </p>
                </template>
            </Card>
        </div>
    </div>
</template>
