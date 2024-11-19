<script setup lang="ts">
import {
  NavigationMenu,
  NavigationMenuContent,
  NavigationMenuItem,
  NavigationMenuLink,
  NavigationMenuList,
  NavigationMenuTrigger,
  navigationMenuTriggerStyle,
} from "../components/ui/navigation-menu";
import { Button } from "./ui/button";

const components: { title: string; href: string; description: string }[] = [
  {
    title: "Alert Dialog",
    href: "/docs/components/alert-dialog",
    description:
      "A modal dialog that interrupts the user with important content and expects a response.",
  },
  {
    title: "Hover Card",
    href: "/docs/components/hover-card",
    description:
      "For sighted users to preview content available behind a link.",
  },
  {
    title: "Progress",
    href: "/docs/components/progress",
    description:
      "Displays an indicator showing the completion progress of a task, typically displayed as a progress bar.",
  },
  {
    title: "Scroll-area",
    href: "/docs/components/scroll-area",
    description: "Visually or semantically separates content.",
  },
  {
    title: "Tabs",
    href: "/docs/components/tabs",
    description:
      "A set of layered sections of content—known as tab panels—that are displayed one at a time.",
  },
  {
    title: "Tooltip",
    href: "/docs/components/tooltip",
    description:
      "A popup that displays information related to an element when the element receives keyboard focus or the mouse hovers over it.",
  },
];
</script>

<template>
  <NavigationMenu class="hidden md:flex">
    <NavigationMenuList>
      <NavigationMenuItem>
        <RouterLink
          to="/"
          :class="navigationMenuTriggerStyle()"
          class="hover:cursor-pointer"
        >
          Início
        </RouterLink>
      </NavigationMenuItem>
      <NavigationMenuItem>
        <RouterLink
          to="/movies"
          :class="navigationMenuTriggerStyle()"
          class="hover:cursor-pointer"
        >
          Todos os Filmes
        </RouterLink>
      </NavigationMenuItem>
      <NavigationMenuItem>
        <RouterLink
          to="/favorites"
          :class="navigationMenuTriggerStyle()"
          class="hover:cursor-pointer"
        >
          Favoritos
        </RouterLink>
      </NavigationMenuItem>

      <NavigationMenuItem>
        <RouterLink
          to="/login"
          :class="navigationMenuTriggerStyle()"
          class="hover:cursor-pointer"
        >
          Entrar
        </RouterLink>
      </NavigationMenuItem>
    </NavigationMenuList>
  </NavigationMenu>
</template>