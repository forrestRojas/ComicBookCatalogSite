<template>
    <section>
        <comic-collection
            v-for="collection in comicCollections" 
            v-bind:key="collection.id"
        ></comic-collection>
    </section>
</template>

<script>
import ComicCollection from '@/components/collections/ComicCollection.vue';

export default {
  name: 'collections',
  components: {
      ComicCollection
  },
  props: {
      comicCollections: Array
  }
}
</script>

<style>

</style>
