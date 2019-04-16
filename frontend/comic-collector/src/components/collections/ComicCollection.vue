<template>
	<article class="collection" v-on:click="GotoCollection()">
		<picture class="collection-img">
			<source v-bind:srcset="collection.image" />
			<img v-bind:src="collection.image" alt="Collection image." />
		</picture>
		<h4 class="collection-name">{{collection.title}}</h4>
		<user v-bind:id="collection.userId"></user>
		<!-- <user-name v-bind:userId="collection.userId"></user-name> -->
		<p class="collection-description">{{collection.description}}</p>
	</article>
</template>

<script>
import User from '@/components/login/User.vue';

export default {
	name: 'comic-collection',
	components: {
		User
	},
	props: {
			collection: Object,
	},
	methods: {
		GotoCollection() {
			this.$router.push({ path: `/collections/${this.collection.id}` });
		}
	}
}
</script>

<style>
:root {
	--grad-color: var(--black-olive);
}

@keyframes gradient {
  0% 	{background: radial-gradient(circle at center, rgba(233, 79, 55, 0.0 ) 	0%, var(--grad-color)	 0%, var(--grad-color) 100%);}
	5% 	{background: radial-gradient(circle at center, rgba(233, 79, 55, 0.3 )	4%, var(--grad-color)	 5%, var(--grad-color) 100%);}
	10% {background: radial-gradient(circle at center, rgba(233, 79, 55, 0.3 )	9%, var(--grad-color) 10%, var(--grad-color) 100%);}
	15% {background: radial-gradient(circle at center, rgba(233, 79, 55, 0.3 ) 14%, var(--grad-color) 15%, var(--grad-color) 100%);}
  25% {background: radial-gradient(circle at center, rgba(233, 79, 55, 0.3 ) 24%, var(--grad-color) 25%, var(--grad-color) 100%);}
	35% {background: radial-gradient(circle at center, rgba(233, 79, 55, 0.3 ) 34%, var(--grad-color) 35%, var(--grad-color) 100%);}
	45% {background: radial-gradient(circle at center, rgba(233, 79, 55, 0.3 ) 44%, var(--grad-color) 45%, var(--grad-color) 100%);}
  50% {background: radial-gradient(circle at center, rgba(233, 79, 55, 0.5 ) 49%, var(--grad-color) 50%, var(--grad-color) 100%);}
	55% {background: radial-gradient(circle at center, rgba(233, 79, 55, 0.5 ) 54%, var(--grad-color) 55%, var(--grad-color) 100%);}
	60% {background: radial-gradient(circle at center, rgba(233, 79, 55, 0.5 ) 59%, var(--grad-color) 60%, var(--grad-color) 100%);}
	65% {background: radial-gradient(circle at center, rgba(233, 79, 55, 0.5 ) 64%, var(--grad-color) 65%, var(--grad-color) 100%);}
	70% {background: radial-gradient(circle at center, rgba(233, 79, 55, 0.5 ) 69%, var(--grad-color) 70%, var(--grad-color) 100%);}
  75% {background: radial-gradient(circle at center, rgba(233, 79, 55, 0.8 ) 74%, var(--grad-color) 75%, var(--grad-color) 100%);}
	80% {background: radial-gradient(circle at center, rgba(233, 79, 55, 0.8 ) 79%, var(--grad-color) 80%, var(--grad-color) 100%);}
	85% {background: radial-gradient(circle at center, rgba(233, 79, 55, 0.8 ) 84%, var(--grad-color) 85%, var(--grad-color) 100%);}
	90% {background: radial-gradient(circle at center, rgba(233, 79, 55, 0.8 ) 89%, var(--grad-color) 90%, var(--grad-color) 100%);}
	95% {background: radial-gradient(circle at center, rgba(233, 79, 55, 0.8 ) 94%, var(--grad-color) 95%, var(--grad-color) 100%);}
  100% {
    color: #fff;
    background: radial-gradient(circle at center, var(--carmine-pink) 99%, var(--grad-color) 100%, var(--grad-color) 100%);
  }
}

@keyframes hoverGrad { 
    0%{background-position:0% 50%}
    50%{background-position:100% 50%}
    100%{background-position:0% 50%}
}

.collection {
	padding: 5%;
	transition: background-color .4s;
	background: inherit;
	color: var(--black-olive)
}

.collection:hover {
	background: var(--carmine-pink); /* rgba(233, 79, 55) */
	animation: gradient 300ms ease;
	color: var(--isabelline);
}

.collection:hover .collection-img img {
	bottom: 4px;
	max-width: 75%;
	box-shadow: 5px 10px rgba(44, 14, 9, 0.671);
}

.collection:active {
	background: #f88;
}

.collection-img img {
	transition: all .5s ease;
	bottom: 0;
	position: relative;
	max-width: 75%;
	box-shadow: none;
}

</style>
