<template>
  <section class="h-100vh flex justify-center items-center">
    <div class="w-[90%] border-2 my-0 mx-auto p-4 rounded-2xl">
      <ToggleGroup type="single" v-model="optionUser" class="justify-start">
        <ToggleGroupItem value="user" aria-label="Toggle User">
          User
        </ToggleGroupItem>
        <ToggleGroupItem value="userAdmin" aria-label="Toggle User Admin">
          User Admin
        </ToggleGroupItem>
      </ToggleGroup>
      <form @submit.prevent="" class="mt-4">
        <div class="grid w-full max-w-sm text-left gap-1.5 my-0 mx-auto">
          <Label for="user">User</Label>
          <Input id="user" type="text" placeholder="user" />
        </div>
        <div class="grid w-full max-w-sm text-left gap-1.5 my-0 mx-auto mt-4">
          <Label for="password">Password</Label>
          <Input id="password" type="password" placeholder="password" />
        </div>
        <Button class="mt-4">Sign-in</Button>
        <Button class="mt-4 ml-2">Sign-out</Button>
      </form>
    </div>
  </section>
</template>

<script setup lang="ts">
import { ToggleGroup, ToggleGroupItem } from "@/components/ui/toggle-group";
import { Input } from "../components/ui/input";
import { Label } from "../components/ui/label";
import { ref } from "vue";
import { Button } from "../components/ui/button";

const optionUser = ref("user");
</script>

<style scoped>
</style>