<template>
    <article>
    <h2>Recently Updated Collections</h2>
    <collections-grid v-bind:comicCollections="recentlyedited"></collections-grid>

    </article>
</template>

<script>
import CollectionsGrid from '@/components/collections/CollectionsGrid.vue';

export default {
name: "recently-updated",
components:{
    CollectionsGrid
},
data(){
    return {
        recentlyedited: []
        
    }
},
created(){

    fetch(`${process.env.VUE_APP_REMOTE_API}/statistics/recentactivity`, {
        method: "GET",
    })
    .then(response => response.json())
    .then(json => {this.recentlyedited = json});
}
}
</script>

<style>

</style>