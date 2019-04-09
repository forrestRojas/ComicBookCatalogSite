<template>
  <main>
    <h2>Collections</h2>
    <collections v-bind:comicCollections="collections"></collections>
  </main>
</template>

<script>
import Collections from '@/components/collections/Collections.vue';
export default {
  name: 'collections-view',
  components: {
    Collections
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
