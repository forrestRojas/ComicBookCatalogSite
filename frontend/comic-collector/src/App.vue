<template>
  <div id="app">
    <!-- <img id="logo" alt="logo" src="data:image/svg+xml;base64,PHN2ZyB4bWxucz0iaHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmciIHZpZXdCb3g9IjAgMCAyODcgMTc4Ij48ZGVmcz48c3R5bGU+LmEsLm17ZmlsbDojZjZmN2ViO30uYiwuaHtmaWxsOiNjOTJmMjQ7fS5je2ZpbGw6IzQ2NjY4YTt9LmR7ZmlsbDojMWYxZDFlO30uZSwuaSwuaiwubHtmaWxsOiNmOGM2MDU7fS5mLC5nLC5re2ZpbGw6bm9uZTt9LmYsLmd7c3Ryb2tlOiNjOTJmMjQ7fS5mLC5nLC5oLC5pLC5qLC5rLC5sLC5te3N0cm9rZS1taXRlcmxpbWl0OjEwO30uZiwuaCwubHtzdHJva2Utd2lkdGg6MnB4O30uZ3tzdHJva2Utd2lkdGg6NHB4O30uaCwuaSwuaiwuaywubCwubXtzdHJva2U6IzFmMWQxZTt9LmosLmt7c3Ryb2tlLXdpZHRoOjAuNzVweDt9PC9zdHlsZT48L2RlZnM+PHRpdGxlPmltYWdlc2xvZ288L3RpdGxlPjxyZWN0IGNsYXNzPSJhIiB3aWR0aD0iMjg3IiBoZWlnaHQ9IjE3OCIvPjxyZWN0IGNsYXNzPSJiIiB4PSIxOTQiIHk9IjkzIiB3aWR0aD0iODUiIGhlaWdodD0iODUiLz48cmVjdCBjbGFzcz0iYyIgeD0iMTAxIiB5PSI5MyIgd2lkdGg9Ijg1IiBoZWlnaHQ9Ijg1Ii8+PHJlY3QgY2xhc3M9ImQiIHg9IjgiIHk9IjkzIiB3aWR0aD0iODUiIGhlaWdodD0iODUiLz48cmVjdCBjbGFzcz0iZSIgeD0iMTk0IiB3aWR0aD0iODUiIGhlaWdodD0iODUiLz48cmVjdCBjbGFzcz0iYiIgeD0iMTAxIiB3aWR0aD0iODUiIGhlaWdodD0iODUiLz48cmVjdCBjbGFzcz0iYyIgeD0iOCIgd2lkdGg9Ijg1IiBoZWlnaHQ9Ijg1Ii8+PGNpcmNsZSBjbGFzcz0iZiIgY3g9IjUwLjgiIGN5PSIxMzQuNyIgcj0iMzAuMyIvPjxwb2x5bGluZSBjbGFzcz0iZyIgcG9pbnRzPSIzNSAxMDguOSAzNSAxMjkuMiAzOC45IDEzMy4xIDM4LjkgMTYyLjUiLz48cG9seWxpbmUgY2xhc3M9ImciIHBvaW50cz0iNjYuNiAxMDguOSA2Ni42IDEyOS4yIDYyLjcgMTMzLjEgNjIuNyAxNjIuNSIvPjxjaXJjbGUgY2xhc3M9ImciIGN4PSI1MC44IiBjeT0iMTQ1LjgiIHI9IjguMyIvPjxwb2x5Z29uIGNsYXNzPSJoIiBwb2ludHM9IjE3Ni43IDEyMS4zIDE0NS44IDE1Ni41IDExNC44IDEyMS4zIDEyNS44IDExMC42IDE2NS43IDExMC42IDE3Ni43IDEyMS4zIi8+PHBhdGggY2xhc3M9ImUiIGQ9Ik0xNTgsMTE3LjFhMjAuNCwyMC40LDAsMCwwLTIuNy0yLjNsLS45LS43aDQuM3YzLjZaIi8+PHBhdGggY2xhc3M9ImQiIGQ9Ik0xNTguMywxMTQuNXYyLjNsLTIuNy0yLjNoMi43bS43LS43aC01LjdsMS44LDEuM2EyMC40LDIwLjQsMCwwLDEsMi43LDIuM2wxLjIsMS4ydi00LjhaIi8+PHBhdGggY2xhc3M9ImkiIGQ9Ik0xNTYuOCwxMzUuOGMwLTYuMS0xOC42LS44LTI3LjgtNC4zbDQuNyw1LjFhMTAuMSwxMC4xLDAsMCwxLDExLDEuOUMxNTMuNSwxMzguNSwxNTYuOCwxMzguMywxNTYuOCwxMzUuOFoiLz48cGF0aCBjbGFzcz0iaSIgZD0iTTE2NC44LDExNS4zdjcuMWgtOS4zYzAtMTEuMS0yMS45LTguMy0yMS45LTMuNCwwLDEwLjcsMjQuNy0xLjMsMzAuNiwxMC41bDYuOS03LjVaIi8+PHBhdGggY2xhc3M9ImkiIGQ9Ik0xMzEuNCwxMTQuNWgtNGwtNyw3LjUsMy44LDQuMkMxMjMuNiwxMjIuMywxMjYuNiwxMTcuNywxMzEuNCwxMTQuNVoiLz48cGF0aCBjbGFzcz0iaSIgZD0iTTEzOC45LDE0Mi4zbDYuOSw3LjUsNi43LTcuNEE0Ny43LDQ3LjcsMCwwLDEsMTM4LjksMTQyLjNaIi8+PHBhdGggY2xhc3M9ImoiIGQ9Ik0yMzguNiwxNDAuN2wtNS4zLDguNi03LTEzLjNhMS44LDEuOCwwLDAsMC0xLjUtMWgtOC42bC0xMi0xNC4zaDIxLjlhNS4xLDUuMSwwLDAsMSw0LjQsMi44bDIuOCw1LjcsNS4zLTguNSw1LjIsOC41LDIuOS01LjdhNC45LDQuOSwwLDAsMSw0LjQtMi44aDIxLjhMMjYxLDEzNWgtOC43YTEuOCwxLjgsMCwwLDAtMS41LDFsLTYuOSwxMy4zWiIvPjxwYXRoIGNsYXNzPSJrIiBkPSJNMjA4LDEyNS4zaDE2LjFhMy41LDMuNSwwLDAsMSwzLDJsNS45LDEyLjUsNS42LTkuMiw1LjUsOS4yLDYtMTIuNWEzLjQsMy40LDAsMCwxLDMtMmgxNiIvPjxsaW5lIGNsYXNzPSJrIiB4MT0iMjEyLjMiIHkxPSIxMzAuNSIgeDI9IjIyOC42IiB5Mj0iMTMwLjUiLz48bGluZSBjbGFzcz0iayIgeDE9IjI2NC44IiB5MT0iMTMwLjUiIHgyPSIyNDguNiIgeTI9IjEzMC41Ii8+PHBhdGggY2xhc3M9ImQiIGQ9Ik0yNjAuNywzMC41QTQxLjUsNDEuNSwwLDAsMSwyNDIsMzYuN2wtLjgtNy42LS45LDMuM2gtMy41bC0uOS0zLjMtLjcsNy42YTQxLjEsNDEuMSwwLDAsMS0xOC43LTYuMkwyMDIuMyw0My43YzEyLjQtNC44LDEzLjUtLjUsMTcuOCw0LjFoLjNsNi43LTEuOGE0LjcsNC43LDAsMCwxLDQuNCwxLjFsNy4xLDcuMiw3LjEtNy4yYTQuNyw0LjcsMCwwLDEsNC40LTEuMWw2LjcsMS44aC4zYzQuMy00LjYsNS40LTguOSwxNy44LTQuMVoiLz48ZWxsaXBzZSBjbGFzcz0ibCIgY3g9IjE0NC44IiBjeT0iNDEuNCIgcng9IjMzLjUiIHJ5PSIxOC43Ii8+PHBhdGggY2xhc3M9ImQiIGQ9Ik0xNDQuOCw1NC4ybC00LjYtNmEzLDMsMCwwLDAtNC41LS4zbC0yLjUsMi41TDEzMCw0Ny4zYTQuMSw0LjEsMCwwLDAtNC45LS43LDMuOSwzLjksMCwwLDAtLjgsNmMtNS4xLTIuOS05LjctNi44LTkuNy0xMS4yLDAtNi4zLDgtMTEuNywxNy42LTE0LjRhNS45LDUuOSwwLDAsMC0xLjcsNy4yYzEuMiwyLjQsMy44LDMuMyw2LjUsMi43LDQuNi0xLjEsNC42LTYuMyw0LjYtMTAuNmExMC45LDEwLjksMCwwLDAsMS44LDMuMWgyLjdhMTAuOSwxMC45LDAsMCwwLDEuOC0zLjFjMCw0LjMsMCw5LjUsNC43LDEwLjYsMi42LjYsNS4zLS4zLDYuNC0yLjdhNiw2LDAsMCwwLTEuNi03LjJjOS41LDIuNywxNy41LDguMSwxNy41LDE0LjQsMCw0LjQtNC42LDguMy05LjYsMTEuMmE0LDQsMCwwLDAtLjgtNiw0LjIsNC4yLDAsMCwwLTUsLjdsLTMuMSwzLjEtMi42LTIuNWEzLDMsMCwwLDAtNC41LjNaIi8+PHBhdGggY2xhc3M9Im0iIGQ9Ik0zMS40LDMzLjlhMTEuOSwxMS45LDAsMCwxLTMuOC04LjMsOS4zLDkuMywwLDAsMSwyLjEtNS45QzE1LjMsMjguMSwyNC45LDQ2LjYsNDQuMiw2MXMzMC43LDUuMiwzMy4xLjhsLTEtMi42Yy05LjgsOS44LTI5LjktNy44LTI5LjktNy44bC00LjUsNC41TDMwLjcsNDQuNWwtLjgtNS4yWiIvPjxwYXRoIGNsYXNzPSJhIiBkPSJNMzMuOSwyNC4zYTEuMSwxLjEsMCwwLDEsMS4xLS44SDQ4LjJhNC4yLDQuMiwwLDAsMSwzLjMsMS42LDQuNSw0LjUsMCwwLDEsLjgsMy43QzQ1LjQsNTUsNDcuOCw1MCw0MSw1Ni43SDI2LjVhLjguOCwwLDAsMS0uNi0uMi42LjYsMCwwLDEtLjEtLjdaIi8+PHBhdGggY2xhc3M9ImQiIGQ9Ik0zMy40LDI0LjJhMS44LDEuOCwwLDAsMSwuNy0xbC42LS4ySDQ4LjVhNC4xLDQuMSwwLDAsMSwxLjkuNSw0LjgsNC44LDAsMCwxLDIuNCwyLjgsNS44LDUuOCwwLDAsMSwuMywxLjljMCwuMy0uMS42LS4xLjlsLS4zLjgtLjgsMy4zTDQ4LjgsNDZhMjQuNSwyNC41LDAsMCwxLTIuNCw2LjUsMTUuMiwxNS4yLDAsMCwxLTIuMiwyLjdsLTIuMywyLjQtLjQuNEgyNmExLjMsMS4zLDAsMCwxLS42LS43LDIsMiwwLDAsMS0uMS0xLjNsLjItLjcuNC0xLjUsMS41LTUuOWMxLjEtMy45LDIuMS03LjgsMy4xLTExLjdabTEsLjJMMjguMyw0Ny45bC0xLjUsNS44LS40LDEuNS0uMi43YS40LjQsMCwwLDAsLjEuM0g0MWwtLjMuMiwyLjQtMi4zYTExLjcsMTEuNywwLDAsMCwyLjEtMi40LDIyLjEsMjIuMSwwLDAsMCwyLjMtNi4xbDMuMi0xMi44LjktMy4zLjItLjhhMS41LDEuNSwwLDAsMCwuMS0uNywzLjIsMy4yLDAsMCwwLS4yLTEuNCwzLjcsMy43LDAsMCwwLTEuOC0yLjIsNC4yLDQuMiwwLDAsMC0xLjUtLjRIMzQuNloiLz48cGF0aCBjbGFzcz0iZCIgZD0iTTYyLjIsMjhjNC45LDUuMiw5LjQsMTAuOSwxMi40LDE3LjRhNDQuNSw0NC41LDAsMCwxLDEuOSw1LjEsNDEuMSw0MS4xLDAsMCwxLDEuMyw1LjMsMTcuNSwxNy41LDAsMCwxLDAsNS42LDEwLjksMTAuOSwwLDAsMS0yLjMsNS4zLDEwLjcsMTAuNywwLDAsMS01LDMuNCwxNS4xLDE1LjEsMCwwLDEtNS45LjgsMzEuMSwzMS4xLDAsMCwxLTEwLjktMi42QTYwLjEsNjAuMSwwLDAsMSwzNS42LDU2LjFhNTUuNyw1NS43LDAsMCwxLTcuMi04LjIsNTAuOSw1MC45LDAsMCwxLTUuNy05LjUsMzQsMzQsMCwwLDEtMy0xMC45LDIwLjMsMjAuMywwLDAsMSwuNS02QTEzLjksMTMuOSwwLDAsMSwyMy4xLDE2YTEyLjIsMTIuMiwwLDAsMSw1LjMtMy4zLDE2LjgsMTYuOCwwLDAsMSw1LjktLjcsMjguNywyOC43LDAsMCwxLDEwLjksMi43TDUwLDE3LjNhNTAuNCw1MC40LDAsMCwxLDQuNCwzLjNsNCwzLjZDNTkuNywyNS40LDYxLDI2LjcsNjIuMiwyOFpNNjEsMjkuMmE1Ni41LDU2LjUsMCwwLDAtOC4yLTYuNCw0MC45LDQwLjksMCwwLDAtOS4zLTQuMiwyNy4zLDI3LjMsMCwwLDAtNC44LTEsMTQuMSwxNC4xLDAsMCwwLTQuNi4xLDcuNCw3LjQsMCwwLDAtMy42LDEuNWwtMSwxLjEtLjYsMS0uMi41LS4yLjVjLS4yLjMtLjIuOC0uNCwxLjJhOC40LDguNCwwLDAsMC0uMywzLjMsMzEuMSwzMS4xLDAsMCwwLDEuNSw4LjUsNDYuOCw0Ni44LDAsMCwwLDQsOC45LDM4LjksMzguOSwwLDAsMCw2LDhBNDcuMiw0Ny4yLDAsMCwwLDU1LjgsNjMuNWEyNS44LDI1LjgsMCwwLDAsOS4xLDIuMiwxNy45LDE3LjksMCwwLDAsNC4xLS4yLDcuOCw3LjgsMCwwLDAsMy42LTEuMyw0LjMsNC4zLDAsMCwwLDEuNi0xLjQsNi40LDYuNCwwLDAsMCwxLjMtMS45LDcuMSw3LjEsMCwwLDAsLjYtMi40LDIyLjYsMjIuNiwwLDAsMCwuMS0yLjZBMjkuNiwyOS42LDAsMCwwLDczLjMsNDYsNTYuNSw1Ni41LDAsMCwwLDYxLDI5LjJaIi8+PHBhdGggY2xhc3M9Im0iIGQ9Ik02NS4yLDYxLjhhMTguMywxOC4zLDAsMCwwLDguNi02LjQsMjQuNSwyNC41LDAsMCwwLTQuNy01LjksOS41LDkuNSwwLDAsMSw1LjgsMS4xbC0uOC02YzIuNSwyLjksMy42LDQuNyw0LjMsOC41LDAsMCwyLjEsMS45LDMsMi45bC0yLDEuN2ExNy43LDE3LjcsMCwwLDEtLjgsNy4ybC0yLjQtNS42Yy0zLjIsMi41LTUuOCwzLTEwLjMsMi4zIi8+PHBhdGggY2xhc3M9ImEiIGQ9Ik03NC44LDI1LjNhMS40LDEuNCwwLDAsMC0uMi0xLjQsMS43LDEuNywwLDAsMC0xLjMtLjdINjIuOGExMS44LDExLjgsMCwwLDAtMTEuNCw4LjlMNDYuOSw0OS42YTIuOCwyLjgsMCwwLDAsMSwyLjlsNC41LDMuNCw3LjQtLjNhOC43LDguNywwLDAsMCw3LjktNi4xWiIvPjxwYXRoIGNsYXNzPSJkIiBkPSJNNzQuNCwyNS4yYTEuMSwxLjEsMCwwLDAtLjMtMS4xLjkuOSwwLDAsMC0uNi0uM0g2Mi4zYTExLjIsMTEuMiwwLDAsMC0xMC4xLDcuNSwzMS44LDMxLjgsMCwwLDAtLjksMy4zTDUwLjQsMzhsLTEuOCw2LjgtLjksMy40LS40LDEuNmEyLjIsMi4yLDAsMCwwLC4yLDEuNGwuNC42Yy4xLjIuNC4zLjYuNWwxLjQsMS4xLDIuOCwyLjFoLS4zbDUuNC0uMiwyLjctLjJhNy4zLDcuMywwLDAsMCwyLjQtLjcsNy45LDcuOSwwLDAsMCwzLjYtMy40LDguNSw4LjUsMCwwLDAsLjktMi40bC44LTIuNlptLjkuM0w2OS41LDQ2LjNsLS43LDIuNmExMS4yLDExLjIsMCwwLDEtMSwyLjcsOSw5LDAsMCwxLTQuMyw0LjEsMTQsMTQsMCwwLDEtMi45LjlINTMuOGwtMS40LS4yaC0uM2wtMi44LTIuMi0xLjQtMS0uNy0uNi0uNi0uOWEzLjQsMy40LDAsMCwxLS4yLTJsLjQtMS43LjktMy40YzEuMi00LjUsMi4zLTksMy42LTEzLjVhMTIuMSwxMi4xLDAsMCwxLDExLTguMmMyLjMtLjEsNC42LDAsNywwaDQuNWwxLC41QTIuNSwyLjUsMCwwLDEsNzUuMywyNS41WiIvPjxwYXRoIGNsYXNzPSJkIiBkPSJNNzEuMywzNy4zSDYyLjJhLjQuNCwwLDAsMS0uNC0uNmMuNC0xLjcsMi4xLTYuNiwyLjUtNy43cy0xLjMtMi4zLTIuMy40LTYsMTktNi4zLDIwLjcsMS4yLDEuOCwyLjUtMS4zQTcwLjksNzAuOSwwLDAsMCw2MC41LDQxYTEuMywxLjMsMCwwLDEsMS4xLS45aDguOFoiLz48cGF0aCBjbGFzcz0iZCIgZD0iTTUzLjEsNTUuNGMxLjUuOCwzLjIsMS44LDQuOSwyLjVhMjUuNCwyNS40LDAsMCwwLDUuNSwxLDE0LjIsMTQuMiwwLDAsMCw1LjQtLjgsMTIuNywxMi43LDAsMCwwLDQuNS0zbC44LjdhNS4yLDUuMiwwLDAsMC0xLjEsMWwtLjUuNi0uNi40LTEuMiwxLTEuMy45LS42LjUtLjcuNS0uOC41LS44LjRhOC43LDguNywwLDAsMS0zLjIuM2MtMi4yLS4zLTQuMS0xLjUtNS45LTIuNGEzMywzMywwLDAsMS01LjEtMy4xWiIvPjxwYXRoIGNsYXNzPSJhIiBkPSJNMjYuNiwxOC41cy0uNSwxMC42LDQuOCwxNS40aDUuOGw2LjEsMjAtMS44LDEuNmEyLjcsMi43LDAsMCwxLTEuOS44SDI5LjVWNDkuN2wtMi0uNCwxLjEtNCwxLjQtLjMsMi4zLDEuMnMtMS4yLTEuMS0yLjctMi44QzI0LjQsMzgsMjAuNCwyOC42LDI2LjYsMTguNVoiLz48cGF0aCBjbGFzcz0iZCIgZD0iTTM1LjcsNTAuOXM1LjktMjEuNyw2LjItMjIuNSwyLjQtMS4yLDEuOS40LTQuNSwxOS4xLTUuOSwyMi45UzM1LjcsNTAuOSwzNS43LDUwLjlaIi8+PHBvbHlnb24gY2xhc3M9ImQiIHBvaW50cz0iMjcgNDkuMyAyOC40IDQ0IDI5LjMgNDQuMiAyNy45IDQ5LjUgMjcgNDkuMyIvPjxwb2x5Z29uIGNsYXNzPSJkIiBwb2ludHM9IjMyIDMzLjYgMzAuNSAzOCAzMSAzMy40IDMyIDMzLjYiLz48L3N2Zz4="> -->
    <logo id="site-logo"></logo>
    <site-header id="site-header"></site-header>
    <site-nav id="site-nav"></site-nav>
    <router-view />
    <!-- <site-footer></site-footer> -->
    <footer id="site-footer">
      <p>This is a Footer</p>
    </footer>
  </div>
</template>

<script>
import SiteHeader from './components/layout/SiteHeader.vue';
import SiteNav from './components/layout/SiteNav.vue';
import Logo from './components/layout/Logo.vue';
// import SiteFooter from './components/layout/SiteFooter.vue';

export default {
  name: 'app',
  components: {
    SiteHeader,
    SiteNav,
    Logo,
    // SiteFooter
  },
}
</script>

<style>
:root {
  --isabelline: #F6F7EB;
  /* --carmine-pink: #E94F37; */
  --carmine-pink: #c92f24;
  --black-olive: #393E41;
  /* --black-olive: #524848; */
  --tufts-blue: #46668a;
  --verdigris: #44BBA4;
  --emmit-yellow: #f8c605;
}

#app {
  font-family: 'Nunito', 'Avenir', Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  background: var(--isabelline);
  color: #2c3e50;
  display: grid;
  min-height: inherit;
  /* min-height: -webkit-fill-available; */
  grid-template-columns: 282.33px 7fr;
  grid-template-rows: auto minmax(72vh, auto) 1fr; 
  grid-template-areas: 
    "logo header"
    "nav main"
    "footer footer";
}
#site-logo {
  grid-area: logo;
  border-top: 8px solid;
  border-top-color: var(--isabelline);
}

#site-footer {
  grid-area: footer;
  font-weight: 300;
  background-color: var(--tufts-blue);
  color: var(--isabelline);
}

#site-header {
  grid-area: header;
  height: 100%;
}
#site-nav {
  grid-area: nav;
  background: inherit;
}
main {
  grid-area: main;
  background: inherit;
}

a {
  text-decoration: none;
  color: var(--carmine-pink);
}

@media screen and (max-width: 1000px) {
  #site-header {
    grid-auto-flow: row;
  }
  #site-header h1 {
    font-size: 6vw;
  }
}

@media screen and (max-width: 640px) {

  #app {
    grid-template-columns: auto;
    grid-template-rows: auto minmax(20vw, auto) 1fr; 
    grid-template-areas: 
      "header"
      "nav"
      "main"
      "footer";
  }

  #site-header h1 {
    font-size: 3em;
  }

  #login-component {
    position: static;
    display: block;
    margin: 0;
    padding: 0;
    width: 100%;
  }

  #login-component .user {
    position: static;
    
  }

  #login-component  .dropdown {
    visibility: visible;
    position: static;
    top: initial;
    border-top: 3px solid var(--emmit-yellow);
    margin: 0;
  }

    #login-component  .dropdown::before {
      width: 0; 
      height: 0;
      top: initial;
      right: initial;
      margin: 8% 0;
      left: -30px;
      border-top: 10px solid transparent;
      border-bottom: 10px solid transparent; 
      border-right: 20px solid var(--isabelline);
  }

  #site-logo {
    display: none;
  }
}

</style>
