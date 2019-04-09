<template>
    <article class="collection">
        <picture class="collection-img">
            <source v-bind:srcset="collection.imageName" />
            <img v-bind:src="collection.imageName" alt="Collection image." />
        </picture>
        <h4 class="collection-name">{{collection.title}}</h4>
        <p class="username">{{userName}}</p>
        <p class="collection-description">{{collection.description}}</p>
    </article>
</template>

<script>
export default {
    name: 'comic-collection',
    props: {
        collection: Object,
        userName: String
    }
}
</script>

<style>

</style>
