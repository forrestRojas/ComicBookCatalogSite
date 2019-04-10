<template>
	<article class="collection" v-on:click="GotoCollection">
		<picture class="collection-img">
			<source v-bind:srcset="collection.imageName" />
			<img v-bind:src="collection.imageName" alt="Collection image." />
		</picture>
		<h4 class="collection-name">{{collection.title}}</h4>
		<user-name v-bind:userId="collection.userId"></user-name>
		<p class="collection-description">{{collection.description}}</p>
	</article>
</template>

<script>
import UserName from '@/components/user/UserName.vue';

export default {
	name: 'comic-collection',
	components: {
		UserName
	},
	props: {
			collection: Object,
	},
	methods: {
		GotoCollection() {
			this.$router.push({ name: 'collections', params: { id: this.collection.id } });
		}
	}
}
</script>

<style>

</style>
