<template>
   <div id="details" class="container">
       <h2>{{comicbook.name}}</h2>
       <img v-bind:src="comicbook.image" class="comic-photo"/>
       <div class="comic-book-details">
           <p>{{comicbook.description}}</p>
           <p>{{comicbook.publisher}}</p>
           <p>{{comicbook.deck}}</p>
           <p>{{comicbook.issuenumber}}</p>
           <p>{{comicbook.volume}}</p>
           <p>{{comicbook.coverdate}}</p>
           <p>{{comicbook.credits}}</p>
       </div>
    </div> 
</template>

<script>
export default {
name: "collections-detail-view",
props: {
    id: Number
},
data(){
    return {
        comicbook:{}
    }
    },
created(){
    const id = this.$route.params.id;
    
    fetch(`${process.env.VUE_APP_REMOTE_API}/comic/${id}`, {
        method: "GET",
    })
    .then(response => response.json())
    .then(json => {
        this.comicbook = json;
    });
}

}
</script>

<style>

</style>
