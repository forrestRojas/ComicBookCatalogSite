<template>
    <article id="popularcomics">
    <h2>Most Popular</h2>
    <div>
    <comic-summary v-for="comic in popularcomics" v-bind:key="comic.id" v-bind:comic="comic" class="statsummary"></comic-summary>
    </div>
    </article>
</template>

<script>
import ComicSummary from '@/components/comics/ComicSummary.vue';

export default {
name: "most-popular",
components:{
    ComicSummary
},
data(){
    return {
        mostpopular: [],
        popularcomics: []
    }
},
created(){
    fetch(`${process.env.VUE_APP_REMOTE_API}/statistics/mostpopular`, {
        method: "GET",
    })
    .then(response => response.json())
    .then(json => {this.mostpopular = json});
    this.getcomics();
},
watch: {
    mostpopular(newList, oldList) {
      if( newList.length > oldList.length) {
          this.getcomics();
      } 
    }
},
methods:{
    getcomics(){
        this.mostpopular.forEach(search => {
            
            fetch(`${process.env.VUE_APP_REMOTE_API}/comic/${search.id}`, {
                method: "GET",
        })
        .then(response => response.json())
        .then(json => {this.popularcomics.push(json)});
        });

    }
}
}
</script>

<style>
#popularcomics div{
    display: flex;
    flex-wrap: wrap;
    justify-content: center;
}
#popularcomics .statsummary {
    grid-template-columns: 1fr;
    grid-auto-flow: row;
    max-width: 300px;
    min-width: 250px;
}
#popularcomics .statsummary picture{
    order: -1;
}
</style>