<template>
    <article>
    <h2>Most Popular</h2>
    <p>{{this.mostpopular}}</p>
    </article>
</template>

<script>
export default {
name: "most-popular",
data(){
    return {
        mostpopular: []
    }
},
created(){

    fetch(`${process.env.VUE_APP_REMOTE_API}/statistics/mostpopular`, {
        method: "GET",
    })
    .then(response => response.json())
    .then(({mostpopular}) => this.mostpopular = mostpopular);
}
}
</script>

<style>

</style>