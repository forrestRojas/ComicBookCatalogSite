<template>
    <article>
        <user v-if="isAuthenticated" v-bind:id="user.id"></user>
        <a v-if="isAuthenticated" href="/logout" v-on:click.prevent="logout">Logout</a>
        <router-link v-else to="/login">Login</router-link>
    </article>
</template>

<script>
import auth from "@/shared/auth";
import User from "@/components/login/User.vue";

export default {
  name: "the-login",
  components: {
    User
  },
  data() {
    return {
      isAuthenticated: auth.getUser() !== null,
      user: {}
    };
  },
  methods: {
    /**
     * Logs the user out and takes them to the login page
     * @function
     */
    logout() {
      auth.destroyToken();
      this.$router.push("/login");
    }
  },
  computed: {
    getUser() {
      return auth.getUser();
    },
  }, 
  created() {
    fetch(`${process.env.VUE_APP_REMOTE_API}/user/${auth.getUser().sub}`, {
        method: "GET",
    })
    .then(response => response.json())
    .then(json => this.user = json);
  }
}
</script>

<style>
  a {
    text-decoration: none;
    color: var(--carmine-pink);
  }
</style>
