import type { InteractionType } from "~/enums/interaction";
import type { Role } from "~/enums/role";


export interface LoginRequest{
  username: string,
  password: string
}

export interface LoginResponse{
  username: string,
  token: string
}
export interface RegisterRequest{
  email: string,
  username: string,
  password: string
}
export interface RegisterResponse{
  username: string,
  email: string,
  token: string
}
export interface UserRequest{
  username: string,
  password: string
}
export interface UserDetail{
id:string,
email: string,
username: string,
bio: string,

}
export interface User{
  id: string,
  username: string,
  displayname?: string,
  avatar: string
}
export interface UserUpdate{
  bio?: string,
  avatar?: string
}
export interface BookmarkResponse{
  userId: string,
  post: PostResponse,
  createdAt: Date,
}
export interface ChatRequest{
  name: string,
}
export interface ChatResponse{
  id: string,
  name: string,
  avatar: string,
  createdAt: Date,
}
export interface ChatUpdate {
  name: string,
  avatar: string,
}
export interface ChatMemberRequest{
  role: Role,
  chatId: string,
  userId: string,
}
export interface ChatMemberResponse{
  id: string,
  role: Role,
  addedAt: Date,
  user: User,
}
export interface ChatMemberUpdate{
  userid: string,
  role: Role,
}
export interface ConnectionResponse{
  follower: User,
  following: User,
  createdAt: Date,
}
export interface MessageRequest{
  chatId: string,
  content: string,
  replyId?: string,
}
export interface MessageResponse{
  id: string,
  sender: User,
  content: string,
  sendDate: Date,
  readDate?: Date,
  editedDate?: Date,
  replyId?: string,
}
export interface MessageUpdate{
  content: string,
}
export interface PostResponse{
  id: string,
  content: string,
  createdAt: Date,
  editedAt?: string,
  imageUrls?: string[],
  previousPostId?: string,
  commentCount: string,
  user: User,
  bookmark?: BookmarkResponse,
}
export interface PostUpdate{
  content: string,
  imageUrls?: string[],
}
export interface PostRequest{
  content: string,
  imageUrls?: string[],
  previousPostId?: string,
}
export interface CommentResponse{
 id: string,
 content: string,
 createdAt: Date,
 editedAt?: string,
 commentCount: string,
 user: User,
 imageUrls?: string[],
 bookmark?: BookmarkResponse,
 previousCommentId?: PostResponse
}
export interface PostInteractionRequest{
  type: InteractionType,
  userId: string,
  postId: string,
}
export interface PostInteractionResponse{
  id: string,
  type: InteractionType,
  user: User,
  post: PostResponse,
  date: Date,
}
export interface PostInteractionUpdate{
  type: InteractionType,
}