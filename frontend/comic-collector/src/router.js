import Vue from "vue";
import Router from "vue-router";
import Home from "./views/Home.vue";
import Login from "./views/Login.vue";
import CollectionsView from "./views/CollectionsView.vue";
import CollectionsDetail from "./views/CollectionsDetail.vue";
import ComicDetails from "./views/ComicDetails.vue";
import UserDetail from "./views/UserDetail.vue";
import auth from "./shared/auth";

Vue.use(Router);

const router = new Router({
    mode: "history",
    base: process.env.BASE_URL,
    routes: [
      {
        path: "/",
        name: "home",
        component: Home,
        meta: {
          requiresAuth: false
        }
      },
      {
        path: "/login",
        name: "login",
        component: Login,
        meta: {
          requiresAuth: false
        }
      },
      {
        path: "/collections",
        name: "collections",
        component: CollectionsView,
        meta: {
          requiresAuth: false
        }
      },
      {
        path: "/collections/:id",
        name: "collection",
        component: CollectionsDetail,
        meta: {
          requiresAuth: false
        }
      },
      {
        path: "/comic/:id",
        name: "comic",
        component: ComicDetails,
        meta: {
          requiresAuth: false
        }
      },
      {
      path: "/account/:id",
      name: "user",
      component: UserDetail,
      meta: {
        requiresAuth: false
      }
    },

    ]
  });

  router.beforeEach((to, from, next) => {
    // Determine if the route requires Authentication
    const requiresAuth = to.matched.some(x => x.meta.requiresAuth);
    const user = auth.getUser();
  
    // If it does and they are not logged in, send the user to "/login"
    if (requiresAuth && !user) {
      next("/login");
    } else {
      // Else let them go to their next destination
      next();
    }
  });
  
  export default router;
  