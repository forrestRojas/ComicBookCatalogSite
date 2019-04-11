<template>
  <main>
    <h2>{{collection.title}}</h2>
    <comic-summary v-for="comic in collection.comics" v-bind:key="comic.id" v-bind:comic="comic"></comic-summary>
  </main>
</template>

<script>
import ComicSummary from '@/components/comics/ComicSummary.vue';

export default {
  name: 'collection-view',
  components: {
    ComicSummary
  },
  data() {
    return {
      collection: []
    };
  },
  created() {
    const id = this.$route.params.id;

    fetch(`${process.env.VUE_APP_REMOTE_API}/collections/${id}`, {
      method: 'GET'
    })
    .then(response => response.json())
    .then(json => {
      this.collection = json;
    });
  },

}
</script>

<style>

</style>
