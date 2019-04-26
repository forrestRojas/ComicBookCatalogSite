<template>
    
</template>

<script>
import dialogPolyfill from 'dialog-polyfill';
export default {

    methods: {
        polyfillDialog() { 
            const dialogTag = document.querySelector('dialog');
            dialogPolyfill.registerDialog(dialogTag);
        },
    }
}
</script>

<style>

</style>
