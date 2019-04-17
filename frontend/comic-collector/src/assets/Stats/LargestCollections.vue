<template>
    <article>
    <h2>Largest Collections</h2>
    <p>{{this.largestcollections}}</p>
    </article>
</template>

<script>
export default {
name: "largest-collections",
data(){
    return {
        largestcollections: 0
        
    }
},
created(){
    const id = this.$route.params.id;

    fetch(`${process.env.VUE_APP_REMOTE_API}/statistics/largestcollections`, {
        method: "GET",
    })
    .then(response => response.json())
    .then(({largestcollections}) => this.largestcollections = largestcollections);
}
}
</script>

<style>

</style>