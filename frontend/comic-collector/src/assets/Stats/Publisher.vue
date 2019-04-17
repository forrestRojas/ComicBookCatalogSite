<template>
    <article>
    <h2>Publisher</h2>
    <p>{{this.publisher}}</p>
    </article>
</template>

<script>
export default {
name: "publisher",
data(){
    return {
        publisher: 0
        
    }
},
created(){
    const id = this.$route.params.id;

    fetch(`${process.env.VUE_APP_REMOTE_API}/statistics/publisher`, {
        method: "GET",
    })
    .then(response => response.json())
    .then(({publisher}) => this.publisher = publisher);
}
}
</script>

<style>

</style>
