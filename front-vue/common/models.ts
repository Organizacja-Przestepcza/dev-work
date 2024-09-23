
export interface Contact {
    avatar :string,
    username :string
}

export interface Post {
    id :string,
    content :string,
    createdAt :Date,
    editedAt? :string,
    imageUrls? :string[]
    previousPostId? :string
}