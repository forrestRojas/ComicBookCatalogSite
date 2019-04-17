<template>
  <main id="collections">
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
        method: 'GET',
        headers: {

        }
      })
      .then(response => response.json())
      .then(json => {
        this.collections = json;
      });
    }
}
</script>

<style>
#collections {
    display: flex;
    flex-flow: column nowrap;
    align-content: stretch;
}

#collections .collections-grid {
  flex-grow: 1;
}

</style>
