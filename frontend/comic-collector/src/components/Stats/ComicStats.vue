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

import TopUser from '@/components/Stats/TopUser.vue';
import LargestCollections from '@/components/Stats/LargestCollections.vue';
import MostPopular from '@/components/Stats/MostPopular.vue';
import Publisher from '@/components/Stats/Publisher.vue';
import TotalCollections from '@/components/Stats/TotalCollections.vue';
import TotalComics from '@/components/Stats/TotalComics.vue';
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

