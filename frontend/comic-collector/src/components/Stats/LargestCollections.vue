<template>
    <article>
    <h2>Largest Collections</h2>
    <collections-grid v-bind:comicCollections="largestcollections"></collections-grid>

    </article>
</template>

<script>
import CollectionsGrid from '@/components/collections/CollectionsGrid.vue';

export default {
name: "largest-collections",
components:{
    CollectionsGrid
},
data(){
    return {
        largestcollections: []
        
    }
},
created(){

    fetch(`${process.env.VUE_APP_REMOTE_API}/statistics/largestcollections`, {
        method: "GET",
    })
    .then(response => response.json())
    .then(json => {this.largestcollections = json});
}
}
</script>

<style>

</style>