<template>
    <article class="collection">
        <picture class="collection-img">
            <source srcset="#">
            <img v-bind:src="collection.imageName" alt="#" />
        </picture>
        <h4 class="collection-name"></h4>
        <p class="username"></p>
        <p class="collection-description"></p>
    </article>
</template>

<script>
export default {
    name: 'comic-collection',
    props: {
        collection: Object
    }
}
</script>

<style>

</style>
