<template>
   <main id="details">
      
       <!-- <section class="comic-book-details"> -->
            <h2>{{comicbook.name}}</h2>
        <picture>
           <source v-bind:src="comicbook.image">
            <img v-bind:src="comicbook.image" class="comic-photo"/>
       </picture>

           <p>Description: {{comicbook.description}}</p>
           <p>Publisher: {{comicbook.publisher}}</p>
           <p>Deck: {{comicbook.deck}}</p>
           <p>Issue Number: {{comicbook.issuenumber}}</p>
           <p>Volume: {{comicbook.volume}}</p>
           <p>Cover Date: {{comicbook.coverdate}}</p>
           <p>Credits: {{comicbook.credits}}</p>
       <!-- </section> -->
        
   </main> 
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
.comic-photo {
    width: 280px;
}
</style>
