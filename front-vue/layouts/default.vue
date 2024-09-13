<template>
    <div class="flex">
        <!-- Left panel (for menu)-->
        <div class="hidden md:flex w-1/5 p-4 h-screen justify-center">
            <Button class="h-fit">
                <Icon name="material-symbols:menu" />
            </Button>
        </div>

        <!-- Main area -->
        <div class="flex-grow p-4 text-center">
            <slot />
        </div>

        <!-- Right panel (for friends)-->
        <div class="hidden w-1/5 p-4 h-screen justify-center">
            <p>This is the right panel.</p>
        </div>
    </div>
</template>