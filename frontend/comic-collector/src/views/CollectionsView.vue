<template>
  <main>
    <h2>Collections</h2>
    <collections-grid v-bind:comicCollections="collections"></collections-grid>
  </main>
</template>

<script>
import CollectionsGrid from '@/components/collections/CollectionsGrid.vue';
export default {
  name: 'collections-view',
  components: {
    CollectionsGrid
  },
  data() {
    return {
      collections: []
    };
  },
  created() {
    fetch(`${process.env.VUE_APP_REMOTE_API}/collections`, {
      method: 'GET'
    })
    .then(response => response.json())
    .then(json => {
      this.collections = json;
    });
  },
  methods: {
  }
}
</script>

<style>

</style>
