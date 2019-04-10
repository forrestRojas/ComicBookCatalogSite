<template>
	<article class="collection" v-on:click="GotoCollection">
		<picture class="collection-img">
			<source v-bind:srcset="collection.image" />
			<img v-bind:src="collection.image" alt="Collection image." />
		</picture>
		<h4 class="collection-name">{{collection.title}}</h4>
		<p>UserName</p>
		<!-- <user-name v-bind:userId="collection.userId"></user-name> -->
		<p class="collection-description">{{collection.description}}</p>
	</article>
</template>

<script>
// import UserName from '@/components/user/UserName.vue';

export default {
	name: 'comic-collection',
	// components: {
	// 	UserName
	// },
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
@keyframes gradient {
  0% {
    background: radial-gradient(circle at center, rgba( 255, 125 , 125, 0 ) 0%, #fff 0%, #fff 100%);
	}
	15% {
    background: radial-gradient(circle at center, rgba( 255, 125, 125, 0.3 ) 14%, #fff 15%, #fff 100%);
  }
  25% {
    background: radial-gradient(circle at center, rgba( 255, 125, 125, 0.3 ) 24%, #fff 25%, #fff 100%);
	}
	35% {
    background: radial-gradient(circle at center, rgba( 255, 125, 125, 0.3 ) 34%, #fff 35%, #fff 100%);
	}
	45% {
    background: radial-gradient(circle at center, rgba( 255, 125, 125, 0.3 ) 44%, #fff 45%, #fff 100%);
  }
  50% {
    background: radial-gradient(circle at center, rgba( 255, 125, 125, 0.5 ) 49%, #fff 50%, #fff 100%);
	}
	55% {
    background: radial-gradient(circle at center, rgba( 255, 125, 125, 0.5 ) 54%, #fff 55%, #fff 100%);
  }
  75% {
    background: radial-gradient(circle at center, rgba( 255, 125, 125, 0.8 ) 74%, #fff 75%, #fff 100%);
  }
  100% {
    color: #fff;
    background: radial-gradient(circle at center, #f88 99%, #fff 100%, #fff 100%);
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
	background: #fff;
}

.collection:hover {
  background: #f88;
	animation: gradient 300ms ease;
	color: #fff;
}

.collection:active {

}

</style>
