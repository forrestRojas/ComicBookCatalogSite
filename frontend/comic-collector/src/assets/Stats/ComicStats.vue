<template>
    <article>
        <p>{{BestUser}}</p>
        <p>{{largestcollections}}</p>
        <p>{{MostPopular}}</p>
        <p>{{Publisher}}</p>
        <p>{{TotalCollections}}</p>
        <p>{{TotalComics}}</p>
    </article>
</template>

<script>

import TopUser from '@/assets/Stats/TopUser.vue';
import LargestCollections from '@/assets/Stats/LargestCollections.vue';
import MostPopular from '@/assets/Stats/MostPopular.vue';
import Publisher from '@/assets/Stats/Publisher.vue';
import TotalCollections from '@/assets/Stats/TotalCollections.vue';
import TotalComics from '@/assets/Stats/TotalComics.vue';
export default {
    data(){
        return{
            topuser: 0,
            largestcollections: 0,
            largestcollections: 0,
            mostpopular: 0,
            publisher: 0,
            totalcollections: 0,
            totalcomics: 0
        }
    }

}
</script>

<style>

</style>

