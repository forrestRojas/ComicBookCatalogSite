<template>
    <article class="totalcollections">
    <h2>Total Collections</h2>
    <p>{{totalcollections}}</p>
    </article>
</template>

<script>
export default {
name: "total-collections",
data(){
    return {
        totalcollections: Number
    }
},
created(){

    fetch(`${process.env.VUE_APP_REMOTE_API}/statistics/totalcollections`, {
        method: "GET",
    })
    .then(response => response.json())
    .then(json => {this.totalcollections = json});
}
}
</script>

<style>
.totalcollections {
    width: 250px;
}
</style>