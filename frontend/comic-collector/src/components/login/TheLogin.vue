<template>
    <div>
        <div v-if="isAuthenticated">
          <p>Hello {{user}}</p>
            <a href="/logout" v-on:click.prevent="logout">Logout</a>
        </div>
        <div v-else>
            <router-link to="/login">Login</router-link>
        </div>
    </div>
</template>

<script>
import auth from "@/shared/auth";

export default {
  name: "the-login",
  data() {
    return {
      isAuthenticated: auth.getUser() !== null,
      user: auth.getUser().sub
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
  }
}
</script>

<style>
  a {
    text-decoration: none;
  }
</style>
