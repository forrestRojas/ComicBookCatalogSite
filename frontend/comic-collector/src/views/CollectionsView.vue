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
  methods: {
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
}
</script>

<style>

</style>
